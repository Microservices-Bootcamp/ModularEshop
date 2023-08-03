using Microsoft.Extensions.DependencyInjection;
using Shipping.Application.Usecases;

namespace Shipping.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<AddToCartEventHandler>();
        return services;
    }
}