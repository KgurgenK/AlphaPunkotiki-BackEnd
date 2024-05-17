using AlphaPunkotiki.Domain.Entities.Base;
using AlphaPunkotiki.Infrastructure.Extensions.Interfaces;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AlphaPunkotiki.Infrastructure.Options;
using Microsoft.IdentityModel.Tokens;

namespace AlphaPunkotiki.Infrastructure.Extensions;

public class JwtTokenGenerator(IOptions<AuthenticationOptions> authenticationOptions) : IJwtTokenGenerator
{
    public string Generate(User user)
    {
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(authenticationOptions.Value.SigningKey)), SecurityAlgorithms.HmacSha256);

        var claims = new Claim[]
        {
            new(ClaimTypes.Role, user.GetType().Name),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

        var token = new JwtSecurityToken(
            authenticationOptions.Value.Issuer,
            authenticationOptions.Value.Audience,
            claims: claims,
            expires: DateTimeOffset.Now.AddDays(14).DateTime,
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
