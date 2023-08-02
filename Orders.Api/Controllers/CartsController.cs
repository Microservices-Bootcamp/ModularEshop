using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.UseCases;
using Orders.Application.UseCases.Dtos;

namespace Orders.Api.Controllers;

[ApiController]
[Route("/carts")]
public class CartsController : ControllerBase
{
    private AddToCart _addToCart;

    public CartsController(AddToCart addToCart)
    {
        _addToCart = addToCart;
    }

    [HttpPost("/carts/add-to-cart")]
    public async Task<IActionResult> AddToCart(AddToCartRequest request)
    {
        var cartId = await _addToCart.Execute(request);
        return Ok(new AddToCartResponse { CartId = cartId });
    }
}

public class AddToCartResponse
{
    public Guid CartId { get; set; }
}