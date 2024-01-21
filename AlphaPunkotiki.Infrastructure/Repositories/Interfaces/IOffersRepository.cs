using AlphaPunkotiki.Domain.Entities.Base;

namespace AlphaPunkotiki.Infrastructure.Repositories.Interfaces;

public interface IOffersRepository<T> 
    : IRepository<T>
    where T : Offer
{
    Task<IReadOnlyList<T>> GetAllAsync();

    Task<IReadOnlyList<T>> GetManyByCreatorIdAsync(Guid creatorId);
}
