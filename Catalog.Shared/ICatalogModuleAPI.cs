namespace Catalog.Shared;

public interface ICatalogModuleAPI
{
    Task<ProductDto?> GetProductBySku(string sku);
}

public record ProductDto(
    string Sku,
    string Name,
    Guid CategoryId,
    string Description,
    decimal CostPrice,
    decimal SellingPrice,
    int Count,
    bool IsAvailable
);
