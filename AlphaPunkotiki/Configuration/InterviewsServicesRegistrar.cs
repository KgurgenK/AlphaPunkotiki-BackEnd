using AlphaPunkotiki.Infrastructure.Repositories;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using AlphaPunkotiki.Infrastructure.Services;
using AlphaPunkotiki.Infrastructure.Services.Interfaces;

namespace AlphaPunkotiki.WebApi.Configuration;

public static class InterviewsServicesRegistrar
{
    public static IServiceCollection AddInterviewsServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IInterviewsService, InterviewsService>()
            .AddScoped<IInterviewsRepository, InterviewsRepository>()
            .AddScoped<IInterviewRequestsRepository, InterviewRequestsRepository>();
    }
}
