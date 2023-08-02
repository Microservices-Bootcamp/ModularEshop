using Microsoft.Extensions.DependencyInjection;
using Orders.Application.UseCases;
using Orders.Infrastructure;

namespace Orders.Api;

public static class Extensions
{
    public static IServiceCollection AddOrderModule(this IServiceCollection services)
    {
        services.AddOrdersInfrastructure()
            .AddTransient<CartItemModifedHandler>()
            .AddTransient<AddToCart>();
        return services;
    }
}