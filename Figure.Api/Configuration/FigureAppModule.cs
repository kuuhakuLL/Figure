using Figure.Api.Logics.CalcArea;
using Figure.Api.Logics.RightTriangle;
using Microsoft.Extensions.DependencyInjection;

namespace Figure.Api.Configuration; 

public static class FigureAppModule {
    public static IServiceCollection FigureConfiguration(this IServiceCollection services) {
        services.AddTransient<FigureFactory>();
        services.AddTransient<CalcAreas>();
        services.AddTransient<ITriangleChecker, RightTriangleChecker>();

        return services;
    }
}