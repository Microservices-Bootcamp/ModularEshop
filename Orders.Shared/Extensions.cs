using Microsoft.Extensions.DependencyInjection;

namespace Orders.Shared;

public static class Extensions
{
    public static IServiceCollection AddOrdersShared(this IServiceCollection services)
    {
        return services;
    }
}