using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories.Base;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlphaPunkotiki.Infrastructure.Repositories;

public class SurveysRepository(IAppDbContext context)
    : RepositoryBase<Survey>(context), ISurveysRepository
{
    public async Task<IReadOnlyList<Survey>> GetAllAsync()
        => await DbContext.Set<Survey>().ToListAsync();

    public async Task<IReadOnlyList<Survey>> GetManyByCreatorIdAsync(Guid creatorId)
        => await DbContext.Set<Survey>().Where(x => x.CreatorId == creatorId).ToListAsync();
}
