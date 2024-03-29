﻿using System.Linq.Expressions;
using AlphaPunkotiki.Domain.Entities.Interfaces;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IReadOnlyList<T>> GetManyAsync(Expression<Func<T, bool>>? filter = default)
    {
        var entities = DbContext.Set<T>();

        return await entities.Where(filter ?? (_ => true)).ToListAsync();
    }
}
