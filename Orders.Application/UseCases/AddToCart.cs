using Orders.Application.Contracts;
using Orders.Application.UseCases.Dtos;
using Orders.Domain;
using Microsoft.Extensions.Logging;

namespace Orders.Application.UseCases;

public class AddToCart
{
    private readonly ICatalogGateway _catalogGateway;
    private readonly ICartRepo _cartRepo;
    private readonly ILogger<AddToCart> _logger;
    private readonly ICartPublisher _cartPublisher;

    public AddToCart(ICatalogGateway catalogGateway, ICartRepo cartRepo, ILogger<AddToCart> logger, ICartPublisher cartPublisher)
    {
        _catalogGateway = catalogGateway;
        _cartRepo = cartRepo;
        _logger = logger;
        _cartPublisher = cartPublisher;
    }

    public async Task<Guid> Execute(AddToCartRequest request)
    {
        var product = await ThrowIfProductNotAvailable(request);

        var cart = await _cartRepo.GetById(new CartId(new Guid(request.CartId))) ?? Cart.NewCart(request.UserId);

        cart.AddToCart(product, request.ProductQuantity);

        _logger.LogInformation("Adding {Product} SKU to Cart", product);
        await _cartRepo.SaveAsync(cart);

        await _cartPublisher.Publish(new CartItemModified(cart.Id.value));
        
        return cart.Id.value;
    }

    private async Task<Product> ThrowIfProductNotAvailable(AddToCartRequest request)
    {
        var product = await _catalogGateway.GetProductBySku(request.ProductSku);
        if (product == null || product.IsNotAvailable(request.ProductQuantity))
            throw new ProductNotFoundException();
        return product;
    }
}

public class ProductNotFoundException : Exception
{
}
