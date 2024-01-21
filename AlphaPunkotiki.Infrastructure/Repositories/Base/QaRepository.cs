using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Domain.Entities.Interfaces;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;

namespace AlphaPunkotiki.Infrastructure.Repositories.Base;

public abstract class QaRepository<T>(IAppDbContext context) 
    : RepositoryBase<T>(context), IQaRepository<T> 
    where T : class, IAggregationRoot
{
    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await DbContext.Set<T>().AddRangeAsync(entities);

        await DbContext.SaveChangesAsync();
    }
}
