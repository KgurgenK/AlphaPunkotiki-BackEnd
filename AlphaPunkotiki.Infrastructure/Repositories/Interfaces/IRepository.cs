using System.Linq.Expressions;
using AlphaPunkotiki.Domain.Entities.Interfaces;

namespace AlphaPunkotiki.Infrastructure.Repositories.Interfaces;

public interface IRepository<T> where T : IAggregationRoot
{
    Task AddAsync(T entity);

    Task<T?> FindAsync(Guid id);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);

    Task<IReadOnlyList<T>> GetManyAsync(Expression<Func<T, bool>>? filter = default);
}
