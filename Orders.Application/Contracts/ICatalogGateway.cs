using Orders.Domain;

namespace Orders.Application.Contracts;

public interface ICatalogGateway
{
    Task<Product?> GetProductBySku(string sku);
}