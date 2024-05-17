using AlphaPunkotiki.Domain.Entities.Base;

namespace AlphaPunkotiki.Infrastructure.Extensions.Interfaces;

public interface IJwtTokenGenerator
{
    string Generate(User user);
}
