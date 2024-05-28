using AlphaPunkotiki.Domain.Dto;

namespace AlphaPunkotiki.WebApi.Controllers.Models.AccountsController;

public record RegisterRequest(AccountCredentialsDto AccountCredentials, UserDto UserInfo);
