using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.WebApi.Controllers.Models.AccountsController;

public record LoginResponse(User User, string JwtToken);
