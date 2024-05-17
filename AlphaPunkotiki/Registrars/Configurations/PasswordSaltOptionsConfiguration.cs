using AlphaPunkotiki.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace AlphaPunkotiki.WebApi.Registrars.Configurations;

public class PasswordSaltOptionsConfiguration(IConfiguration configuration) : IConfigureOptions<PasswordsSaltOptions>
{
    private const string SettingsSectionName = "PasswordSalt";

    public void Configure(PasswordsSaltOptions options)
        => configuration.Bind(SettingsSectionName, options);
}