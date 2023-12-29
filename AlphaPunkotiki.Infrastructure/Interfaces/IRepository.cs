using AlphaPunkotiki.Domain.Interfaces;

namespace AlphaPunkotiki.Infrastructure.Interfaces;

public interface IRepository<T> where T : IAggregationRoot
{
    Task AddAsync(T entity);

    Task<T> FindAsync(Guid id);

    Task UpdateAsync(T entity);
}