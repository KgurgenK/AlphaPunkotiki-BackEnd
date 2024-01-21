using AlphaPunkotiki.Domain.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlphaPunkotiki.Infrastructure.Database.Interfaces;

public interface IAppDbContext
{
    DbSet<T> Set<T>()
        where T : class, IAggregationRoot;

    Task<int> SaveChangesAsync();
}