using MediatR;
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
    private readonly IMediator _mediator;
    public AddToCart(ICatalogGateway catalogGateway, ICartRepo cartRepo, ILogger<AddToCart> logger, IMediator mediator)
    {
        _catalogGateway = catalogGateway;
        _cartRepo = cartRepo;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<Guid> Execute(AddToCartRequest request)
    {
        var product = await ThrowIfProductNotAvailable(request);

        var cart = await _cartRepo.GetById(new CartId(new Guid(request.CartId))) ?? Cart.NewCart(request.UserId);

        cart.AddToCart(product, request.ProductQuantity);

        _logger.LogInformation("Adding {Product} SKU to Cart", product);
        await _cartRepo.SaveAsync(cart);
        await _mediator.Publish(new CartItemModified(cart.Id.Id));
        return cart.Id.Id;
    }

    private async Task<Product> ThrowIfProductNotAvailable(AddToCartRequest request)
    {
        var product = await _catalogGateway.GetProductBySku(request.ProductSku);
        if (product == null || product.IsNotAvailable(request.ProductQuantity))
            throw new ProductNotFoundException();
        return product;
    }
}

public class CartItemModified : INotification
{
    public CartItemModified()
    {
        
    }
    public CartItemModified(Guid id)
    {
        this.CartId = id;
    }

    public Guid CartId { get; set; }
}

public class ProductNotFoundException : Exception
{
}

public class CartItemModifedHandler : INotificationHandler<CartItemModified>
{
    public Task Handle(CartItemModified notification, CancellationToken cancellationToken)
    {
        Console.Write("Notification received "+ notification.CartId);
        return Task.CompletedTask;
    }
}