using AlphaPunkotiki.Domain.Dto;
using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Domain.Errors;
using AlphaPunkotiki.Infrastructure.Extensions.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using AlphaPunkotiki.Infrastructure.Services.Interfaces;
using AlphaPunkotiki.Infrastructure.Services.Models;
using Kontur.Results;

namespace AlphaPunkotiki.Infrastructure.Services;

public class AccountsService(
    IAccountsRepository accountsRepository,
    IUsersRepository usersRepository,
    IPasswordHashCalculator passwordHashCalculator,
    IJwtTokenGenerator jwtTokenGenerator) : IAccountsService
{
    public async Task<Result<NotFoundError, AuthUserInfo>> LoginAsync(string login, string password)
    {
        var passwordHash = passwordHashCalculator.Calculate(password);
        var user = await accountsRepository.GetUserByLoginAndPassword(login, passwordHash);

        if (user == null)
            return new NotFoundError("Account with provided login or password was not found.");

        var jwtToken = jwtTokenGenerator.Generate(user);

        return new AuthUserInfo(user, jwtToken);
    }

    public async Task<Result<ConflictError>> RegisterAsync(AccountCredentialsDto accountCredentials, UserDto userInfo)
    {
        var (login, password) = accountCredentials;
        var (role, name, email, phoneNumber, description) = userInfo;

        if (await accountsRepository.IsLoginExists(login))
            return new ConflictError($"Account with {nameof(login)} '{login}' already exist.");

        var passwordHash = passwordHashCalculator.Calculate(password);
        var user = new User(role, name, email, phoneNumber, description);

        await usersRepository.AddAsync(user);
        await accountsRepository.AddAsync(new Account(user, login, passwordHash));

        return Result.Succeed();
    }
}
