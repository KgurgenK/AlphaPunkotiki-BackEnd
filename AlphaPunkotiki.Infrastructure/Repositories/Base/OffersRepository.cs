using AlphaPunkotiki.Domain.Entities.Base;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;

namespace AlphaPunkotiki.Infrastructure.Repositories.Base;

public abstract class OffersRepository<T>(IAppDbContext context)
    : RepositoryBase<T>(context), IOffersRepository<T>
    where T : Offer
{
    public Task<IReadOnlyList<T>> GetManyByCreatorIdAsync(Guid creatorId)
        => GetManyAsync(x => x.CreatorId == creatorId);
}

