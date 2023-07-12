using Catalog.Shared;
using Orders.Application.UseCases.Dtos;

namespace Orders.Application.UseCases;

public class AddToCart
{
    private readonly ICatalogModuleAPI _ctatalogModule;
    
    public AddToCart(ICatalogModuleAPI ctatalogModule)
    {
        _ctatalogModule = ctatalogModule;
    }

    public Task Execute(AddToCartRequest request)
    {
        var product = _ctatalogModule.GetProductBySku(request.ProductSku);
        if (product == null)
            throw new ProductNotFoundException();
        
        Console.Write("Adding product SKU to Cart");
        return Task.CompletedTask;
    }
}

public class ProductNotFoundException : Exception
{
}