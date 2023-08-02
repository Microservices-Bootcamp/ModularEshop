using Catalog.Shared;
using Orders.Application.Contracts;
using Orders.Domain;

namespace Orders.Infrastructure;

public class CatalogGateway : ICatalogGateway
{
    private readonly ICatalogModuleAPI _catalogModule;

    public CatalogGateway(ICatalogModuleAPI catalogModule)
    {
        _catalogModule = catalogModule;
    }

    public async Task<Product?> GetProductBySku(string sku)
    {
        var productDto = await _catalogModule.GetProductBySku(sku);
        if (productDto == null) return null;
        return new Product(productDto.Sku, productDto.Name, productDto.SellingPrice, productDto.Count,
            productDto.IsAvailable);
    }
}