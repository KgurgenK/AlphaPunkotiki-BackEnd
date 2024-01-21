using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.Infrastructure.Repositories.Interfaces;

public interface IAnswersRepository : IQaRepository<Answer>
{
    Task<IReadOnlyList<Answer>> GetManyBySurveyIdAsync(Guid surveyId);

    Task<IReadOnlyList<Answer>> GetManyByQuestionIdAsync(Guid questionId);
}
