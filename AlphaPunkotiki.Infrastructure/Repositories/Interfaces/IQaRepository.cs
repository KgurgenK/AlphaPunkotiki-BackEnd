using AlphaPunkotiki.Domain.Entities.Interfaces;

namespace AlphaPunkotiki.Infrastructure.Repositories.Interfaces;

public interface IQaRepository<T>
    : IRepository<T>
    where T : IAggregationRoot
{
    Task AddRangeAsync(IEnumerable<T> entities);
}
