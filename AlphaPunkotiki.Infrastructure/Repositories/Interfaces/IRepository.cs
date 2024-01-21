using AlphaPunkotiki.Domain.Entities.Interfaces;

namespace AlphaPunkotiki.Infrastructure.Repositories.Interfaces;

public interface IRepository<T> where T : IAggregationRoot
{
    Task AddAsync(T entity);

    Task<T?> FindAsync(Guid id);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}
