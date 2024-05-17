using AlphaPunkotiki.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace AlphaPunkotiki.WebApi.Registrars.Configurations;

public class AuthenticationOptionsConfiguration(IConfiguration configuration) : IConfigureOptions<AuthenticationOptions>
{
    private const string SettingsSectionName = "Authentication";

    public void Configure(AuthenticationOptions options)
        => configuration.GetRequiredSection(SettingsSectionName).Bind(options);
}
