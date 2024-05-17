using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AlphaPunkotiki.Infrastructure.Options;

namespace AlphaPunkotiki.WebApi.Registrars.Configurations;

public class JwtBearerOptionsConfiguration(IOptions<AuthenticationOptions> authenticationOptions)
    : IConfigureNamedOptions<JwtBearerOptions>
{
    private const string DefaultJwtBearerOptionsName = "Bearer";

    public void Configure(string? name, JwtBearerOptions options)
    {
        if (name is not null and not DefaultJwtBearerOptionsName)
            return;

        Configure(options);
    }

    public void Configure(JwtBearerOptions options)
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidIssuer = authenticationOptions.Value.Issuer,
            ValidAudience = authenticationOptions.Value.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(authenticationOptions.Value.SigningKey)),
            ValidateIssuerSigningKey = true,
        };
    }
}