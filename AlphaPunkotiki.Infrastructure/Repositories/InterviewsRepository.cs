using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories.Base;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlphaPunkotiki.Infrastructure.Repositories;

public class InterviewsRepository(IAppDbContext context)
    : RepositoryBase<Interview>(context), IInterviewsRepository
{
    public async Task<IReadOnlyList<Interview>> GetAllAsync()
        => await DbContext.Set<Interview>().ToListAsync();

    public async Task<IReadOnlyList<Interview>> GetManyByCreatorIdAsync(Guid creatorId) 
        => await DbContext.Set<Interview>().Where(x => x.CreatorId == creatorId).ToListAsync();
}