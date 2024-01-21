using AlphaPunkotiki.Domain.Dto;
using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using AlphaPunkotiki.Infrastructure.Services.Interfaces;

namespace AlphaPunkotiki.Infrastructure.Services;

public class SurveysService(ISurveysRepository surveysRepository, IQuestionsRepository questionsRepository, 
    IAnswersRepository answersRepository) : ISurveysService
{
    public async Task<(Survey?, IReadOnlyList<Question>)> GetSurveyWithQuestionsAsync(Guid id)
    {
        var survey = await surveysRepository.FindAsync(id);

        if (survey is null)
            return (null, []);

        var questions = await questionsRepository.GetManyBySurveyIdAsync(id);

        return (survey, questions);
    }

    public async Task CreateSurveyAsync(SurveyDto surveyInfo, IReadOnlyList<QuestionDto> questionsInfo)
    {
        var survey = new Survey(
                surveyInfo.CreatorId, 
                surveyInfo.Name, 
                surveyInfo.Description, 
                surveyInfo.Price, 
                surveyInfo.IsLimitedPublicationTime, 
                surveyInfo.PublicationTimeLimit,
                surveyInfo.IsLimitedUsages,
                surveyInfo.UsagesLimit,
                surveyInfo.IsLimitedCompletionTime,
                surveyInfo.CompletionTimeLimit);

        await surveysRepository.AddAsync(survey);
        await questionsRepository.AddRangeAsync(questionsInfo.Select(x =>
            new Question(survey.Id, x.Type, x.Name, x.Tooltip, x.Variables, x.IsRequired)));
    }

    public Task AddAnswersAsync(Guid userId, IReadOnlyList<AnswerDto> answersInfo)
        => answersRepository.AddRangeAsync(answersInfo.Select(x => new Answer(userId, x.QuestionId, x.Values)));

    public Task<IReadOnlyList<Survey>> GetAllAvailableSurveysAsync()
        => surveysRepository.GetManyAsync(x => x.IsAvailable);

    public Task<IReadOnlyList<Survey>> GetUserSurveysAsync(Guid userId) 
        => surveysRepository.GetManyByCreatorIdAsync(userId);

    public async Task<IReadOnlyDictionary<string, (int, float)>> GetStatisticsOfQuestionAsync(Guid questionId)
    {
        var answers = await answersRepository.GetManyByQuestionIdAsync(questionId);
        var answersValues = answers.SelectMany(x => x.Values ?? []);
        var valuesCount = answersValues.Count();
        var result = new Dictionary<string, int>();

        foreach (var answersValue in answersValues)
            result[answersValue] = result.TryGetValue(answersValue, out var value) ? value + 1 : 1;

        return result.ToDictionary(x => x.Key, x => (x.Value, (float)x.Value / valuesCount));
    }
}
