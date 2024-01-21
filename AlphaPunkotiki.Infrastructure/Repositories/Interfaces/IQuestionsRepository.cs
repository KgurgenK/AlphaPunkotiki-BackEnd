using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.Infrastructure.Repositories.Interfaces;

public interface IQuestionsRepository : IQaRepository<Question>
{
    Task<IReadOnlyList<Question>> GetManyBySurveyIdAsync(Guid surveyId);
}