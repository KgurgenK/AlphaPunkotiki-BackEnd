using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories.Base;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlphaPunkotiki.Infrastructure.Repositories;

public class AccountsRepository(IAppDbContext context)
    : RepositoryBase<Account>(context), IAccountsRepository
{
    public Task<User?> GetUserByLoginAndPassword(string login, string passwordsHash)
        => DbContext.Set<Account>()
            .Where(account => account.Login == login && account.PasswordHash == passwordsHash)
            .Select(account => account.User)
            .SingleOrDefaultAsync();

    public Task<bool> IsLoginExists(string login)
        => DbContext.Set<Account>().AnyAsync(account => account.Login == login);
}