using AlphaPunkotiki.Domain.Dto;
using AlphaPunkotiki.Domain.Errors;
using AlphaPunkotiki.Infrastructure.Services.Models;
using Kontur.Results;

namespace AlphaPunkotiki.Infrastructure.Services.Interfaces;

public interface IAccountsService
{
    Task<Result<NotFoundError, AuthUserInfo>> LoginAsync(string login, string password);

    Task<Result<ConflictError>> RegisterAsync(AccountCredentialsDto accountCredentials, UserDto userInfo);
}