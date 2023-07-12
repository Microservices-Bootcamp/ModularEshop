using Catalog.Domain.Contracts;
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Repositories;

public class ProductInMemoryRepo : IProductRepository
{
    private static readonly List<Product> Products = new();

    public async Task Add(Product product)
    {
        Products.Add(product);
    }

    public Task<Product?> GetBySku(string sku)
    {
        return Task.FromResult(Products.SingleOrDefault(x => x.Sku._value == sku));
    }
}