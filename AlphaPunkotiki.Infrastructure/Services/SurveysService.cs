using AlphaPunkotiki.Domain.Dto;
using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Domain.Errors;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using AlphaPunkotiki.Infrastructure.Services.Interfaces;
using Kontur.Results;

namespace AlphaPunkotiki.Infrastructure.Services;

public class SurveysService(ISurveysRepository surveysRepository, IQuestionsRepository questionsRepository, 
    IAnswersRepository answersRepository) : ISurveysService
{
    public async Task<Result<NotFoundError, (Survey, IReadOnlyList<Question>)>> GetSurveyWithQuestionsAsync(Guid id)
    {
        var survey = await surveysRepository.FindAsync(id);

        if (survey is null)
            return new NotFoundError($"Entity with {nameof(id)} '{id}' was not found.");

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
            new Question(survey, x.Type, x.Name, x.Tooltip, x.Variables, x.IsRequired)));
    }

    public async Task<bool> TryAddAnswersAsync(Guid userId, IReadOnlyList<AnswerDto> answersInfo)
    {
        if (answersInfo.Count == 0)
            return false;

        var answers = new List<Answer>();
        var firstQuestion = await questionsRepository.FindAsync(answersInfo[0].QuestionId);

        if (firstQuestion == null || !firstQuestion.Survey.Use())
            return false;

        foreach (var answerInfo in answersInfo)
        {
            var question = await questionsRepository.FindAsync(answerInfo.QuestionId);

            if (question == null || question.Survey != firstQuestion.Survey)
                return false;

            answers.Add(new Answer(userId, question, answerInfo.Values));
        }

        await answersRepository.AddRangeAsync(answers);

        return true;
    }

    public async Task<IReadOnlyList<Survey>> GetAllAvailableSurveysAsync()
    {
        var surveys = await surveysRepository.GetManyAsync();
        
        return await Task.Run(() => surveys.Where(x => x.IsAvailable).ToList());

    }

    public Task<IReadOnlyList<Survey>> GetUserSurveysAsync(Guid userId)
        => surveysRepository.GetManyByCreatorIdAsync(userId);

    public async Task<IReadOnlyDictionary<string, AnswerItemStatisticsDto>> GetStatisticsOfQuestionAsync(Guid questionId)
    {
        var answers = await answersRepository.GetManyByQuestionIdAsync(questionId);

        return await Task.Run(() =>
        {
            var answersValues = answers.SelectMany(x => x.Values ?? []).ToList();
            var result = new Dictionary<string, int>();

            foreach (var answersValue in answersValues)
                result[answersValue] = result.TryGetValue(answersValue, out var value) ? value + 1 : 1;

            return result.ToDictionary(x => x.Key,
                x => new AnswerItemStatisticsDto(x.Value, (float)x.Value / answersValues.Count));
        });
    }
}
