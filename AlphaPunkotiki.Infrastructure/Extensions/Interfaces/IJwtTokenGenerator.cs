using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.Infrastructure.Extensions.Interfaces;

public interface IJwtTokenGenerator
{
    string Generate(User user);
}
