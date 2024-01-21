using AlphaPunkotiki.Domain.Entities.Interfaces;

namespace AlphaPunkotiki.Infrastructure.Repositories.Interfaces;

public interface IQaRepository<T>
    : IRepository<T>
    where T : IAggregationRoot
{
    Task AddRangeAsync(ICollection<T> entities);

    Task<IReadOnlyList<T>> GetManyBySurveyIdAsync(Guid surveyId);
}
