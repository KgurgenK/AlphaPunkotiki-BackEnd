using Microsoft.EntityFrameworkCore;
using AlphaPunkotiki.Domain.Interfaces;

namespace AlphaPunkotiki.Infrastructure.Interfaces;

public interface IAppDbContext
{
    DbSet<T> Set<T>()
        where T : class, IAggregationRoot;

    Task<int> SaveChangesAsync();
}