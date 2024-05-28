using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.Infrastructure.Repositories.Interfaces;

public interface IUsersRepository : IRepository<User>
{
    Task<bool> ExistsAsync(Guid userId);
}
