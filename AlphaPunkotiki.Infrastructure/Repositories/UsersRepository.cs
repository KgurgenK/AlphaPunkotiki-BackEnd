using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories.Base;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlphaPunkotiki.Infrastructure.Repositories;

public class UsersRepository(IAppDbContext context)
    : RepositoryBase<User>(context), IUsersRepository
{
    public Task<bool> ExistsAsync(Guid userId)
        => DbContext.Set<User>().AnyAsync(user => user.Id == userId);
}
