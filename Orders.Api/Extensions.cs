using Microsoft.Extensions.DependencyInjection;
using Orders.Application.UseCases;

namespace Orders.Api;

public static class Extensions
{
    public static IServiceCollection AddOrderModule(this IServiceCollection services)
    {
        services.AddTransient<AddToCart>();
        return services;
    }
}