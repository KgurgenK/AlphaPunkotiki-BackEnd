﻿using AlphaPunkotiki.Domain.Enums;
using AlphaPunkotiki.Infrastructure.Database;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace AlphaPunkotiki.WebApi.Configuration;

public static class PostgresDbContextRegistrar
{
    private const string PostgresConnectionStringName = "PostgreSql";

    public static IServiceCollection AddPostgresDbContext(
        this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var npgsqlDataSourceBuilder =
            new NpgsqlDataSourceBuilder(configuration.GetConnectionString(PostgresConnectionStringName));
        npgsqlDataSourceBuilder.MapEnum<InterviewRequestStatus>();
        npgsqlDataSourceBuilder.MapEnum<QuestionType>();

        return serviceCollection
            .AddDbContext<PostgresDbContext>(options =>
                options
                    .UseNpgsql(npgsqlDataSourceBuilder.Build())
                    .UseLazyLoadingProxies()
            )
            .AddScoped<IAppDbContext, PostgresDbContext>();
    }
}