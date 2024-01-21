using AlphaPunkotiki.Domain.Entities.Interfaces;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;

namespace AlphaPunkotiki.Infrastructure.Repositories.Base;

public abstract class RepositoryBase<T>(IAppDbContext context)
    : IRepository<T>
    where T : class, IAggregationRoot
{
    protected readonly IAppDbContext DbContext = context;

    public async Task AddAsync(T entity)
    {
        await DbContext.Set<T>().AddAsync(entity);

        await DbContext.SaveChangesAsync();
    }

    public async Task<T?> FindAsync(Guid id) 
        => await DbContext.Set<T>().FindAsync(id);

    public async Task UpdateAsync(T entity)
    {
        DbContext.Set<T>().Update(entity);

        await DbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        DbContext.Set<T>().Remove(entity);

        await DbContext.SaveChangesAsync();
    }
}
