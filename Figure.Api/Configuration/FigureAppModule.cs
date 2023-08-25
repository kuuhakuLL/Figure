using Microsoft.Extensions.DependencyInjection;

namespace Figure.Api.Configuration; 

public static class FigureAppModule {
    public static IServiceCollection FigureConfiguration(this IServiceCollection services) {
        services.AddSingleton<FigureFactory>();

        return services;
    }
}