using AlphaPunkotiki.Infrastructure.Repositories;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using AlphaPunkotiki.Infrastructure.Services;
using AlphaPunkotiki.Infrastructure.Services.Interfaces;

namespace AlphaPunkotiki.WebApi.Configuration;

public static class SurveysServicesRegistrar
{
    public static IServiceCollection AddSurveysServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<ISurveysService, SurveysService>()
            .AddScoped<ISurveysRepository, SurveysRepository>()
            .AddScoped<IQuestionsRepository, QuestionsRepository>()
            .AddScoped<IAnswersRepository, AnswersRepository>();
    }
}
