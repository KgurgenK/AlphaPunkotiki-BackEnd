using AlphaPunkotiki.Domain.Interfaces;
using AlphaPunkotiki.Infrastructure.Interfaces;

namespace AlphaPunkotiki.Infrastructure.Base;

public abstract class RepositoryBase<T>(IAppDbContext context) : IRepository<T>
    where T : class, IAggregationRoot
{
    public async Task AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);

        await context.SaveChangesAsync();
    }

    public async Task<T> FindAsync(Guid id)
    {
        var foundEntity = await context.Set<T>().FindAsync(id);

        return foundEntity ?? throw new ArgumentException($"Entity with id {id} not found");
    }

    public async Task UpdateAsync(T entity)
    {
        context.Set<T>().Update(entity);

        await context.SaveChangesAsync();
    }
}