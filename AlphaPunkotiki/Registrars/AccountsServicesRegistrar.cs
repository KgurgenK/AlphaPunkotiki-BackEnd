using AlphaPunkotiki.Infrastructure.Extensions;
using AlphaPunkotiki.Infrastructure.Extensions.Interfaces;
using AlphaPunkotiki.Infrastructure.Options;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories;
using AlphaPunkotiki.Infrastructure.Services.Interfaces;
using AlphaPunkotiki.Infrastructure.Services;
using AlphaPunkotiki.WebApi.Registrars.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AlphaPunkotiki.WebApi.Registrars;

public static class AccountsServicesRegistrar
{
    public static IServiceCollection AddAccountsServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddOptions<PasswordsSaltOptions>();
        serviceCollection.AddOptions<AuthenticationOptions>();
        serviceCollection.ConfigureOptions<AuthenticationOptionsConfiguration>();
        serviceCollection.ConfigureOptions<PasswordSaltOptionsConfiguration>();
        serviceCollection.ConfigureOptions<JwtBearerOptionsConfiguration>();
        serviceCollection
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        return serviceCollection
            .AddScoped<IJwtTokenGenerator, JwtTokenGenerator>()
            .AddScoped<IAccountsRepository, AccountsRepository>()
            .AddScoped<IUsersRepository, UsersRepository>()
            .AddScoped<IAccountsService, AccountsService>()
            .AddScoped<IPasswordHashCalculator, PasswordHashCalculator>();
    }
}
