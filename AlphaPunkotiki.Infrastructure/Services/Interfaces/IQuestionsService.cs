namespace AlphaPunkotiki.Infrastructure.Services.Interfaces;

internal interface IQuestionsService
{
    Task<IReadOnlyDictionary<string, (int, float)>> GetStatisticsOfQuestion(Guid questionId);
}
