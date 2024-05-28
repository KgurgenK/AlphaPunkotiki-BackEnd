using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.Infrastructure.Services.Models;

public record AuthUserInfo(User User, string JwtToken);
