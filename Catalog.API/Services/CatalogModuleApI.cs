using Catalog.Application.UseCases;
using Catalog.Shared;

namespace Catalog.API.Services;

public class CatalogModuleApI : ICatalogModuleAPI
{
    private readonly GetProduct _getProduct;

    public CatalogModuleApI(GetProduct getProduct)
    {
        _getProduct = getProduct;
    }

    public async Task<ProductDto?> GetProductBySku(string sku)
    {
        var product = await _getProduct.Execute(sku);
        if (product == null) return null;
        return new ProductDto(
            product.Sku._value,
            product.Name,
            product.CategoryId,
            product.Description,
            product.CostPrice,
            product.SellingPrice,
            product.Count,
            product.IsAvailable
        );
    }
}