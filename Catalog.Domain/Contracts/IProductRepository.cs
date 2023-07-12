using Catalog.Domain.Entities;

namespace Catalog.Domain.Contracts;

public interface IProductRepository
{
    public Task Add(Product product);
    public Task<Product?> GetBySku(string sku);
}