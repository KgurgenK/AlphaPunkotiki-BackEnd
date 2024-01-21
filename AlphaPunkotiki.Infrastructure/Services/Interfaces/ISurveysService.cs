using AlphaPunkotiki.Domain.Dto;
using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.Infrastructure.Services.Interfaces;

public interface ISurveysService
{
    Task CreateSurveyAsync(SurveyDto surveyInfo, IReadOnlyList<QuestionDto> questionsInfo);

    Task AddAnswersAsync(Guid userId, IReadOnlyList<AnswerDto> answersInfo);

    Task<(Survey?, IReadOnlyList<Question>)> GetSurveyWithQuestionsAsync(Guid surveyId);

    Task<IReadOnlyList<Survey>> GetAllAvailableSurveysAsync();

    Task<IReadOnlyList<Survey>> GetUserSurveysAsync(Guid userId);

    Task<IReadOnlyDictionary<string, (int, float)>> GetStatisticsOfQuestionAsync(Guid questionId);
}
