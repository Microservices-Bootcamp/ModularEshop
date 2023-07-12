using Catalog.API.Services;
using Catalog.Application.UseCases;
using Catalog.Domain.Contracts;
using Catalog.Infrastructure.Repositories;
using Catalog.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.API;

public static class Extensions
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services)
    {
        services.AddTransient<CreateCategory>()
            .AddTransient<CreateProduct>()
            .AddTransient<GetProduct>()
            .AddTransient<ICategoryRepository, CatetgoryInMemoryRepo>()
            .AddTransient<IProductRepository, ProductInMemoryRepo>()
            .AddTransient<ICatalogModuleAPI, CatalogModuleApI>();
        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        return app;
    }
}