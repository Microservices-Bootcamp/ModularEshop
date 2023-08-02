using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Contracts;
using Orders.Domain;

namespace Orders.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddOrdersInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<ICatalogGateway, CatalogGateway>();
        services.AddTransient<ICartRepo, CartRepoInMemory>();
        return services;
    }
}