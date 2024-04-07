using AlphaPunkotiki.Domain.Dto;
using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Domain.Errors;
using Kontur.Results;

namespace AlphaPunkotiki.Infrastructure.Services.Interfaces;

public interface ISurveysService
{
    Task CreateSurveyAsync(SurveyDto surveyInfo, IReadOnlyList<QuestionDto> questionsInfo);

    Task<bool> TryAddAnswersAsync(Guid userId, IReadOnlyList<AnswerDto> answersInfo);

    Task<Result<NotFoundError, (Survey, IReadOnlyList<Question>)>> GetSurveyWithQuestionsAsync(Guid surveyId);

    Task<IReadOnlyList<Survey>> GetAllAvailableSurveysAsync();

    Task<IReadOnlyList<Survey>> GetUserSurveysAsync(Guid userId);

    Task<IReadOnlyDictionary<string, AnswerItemStatisticsDto>> GetStatisticsOfQuestionAsync(Guid questionId);
}
