using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Domain.Errors;
using Kontur.Results;

namespace AlphaPunkotiki.Infrastructure.Repositories.Interfaces;

public interface IAccountsRepository : IRepository<Account>
{
    Task<User?> GetUserByLoginAndPassword(string login, string passwordsHash);

    Task<bool> IsLoginExists(string login);
}
