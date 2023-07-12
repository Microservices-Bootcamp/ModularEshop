using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.UseCases;
using Orders.Application.UseCases.Dtos;

namespace Orders.Api.Controllers;

[ApiController]
[Route("/carts")]
public class CartsController: ControllerBase
{
    private AddToCart _addToCart;

    public CartsController(AddToCart addToCart)
    {
        _addToCart = addToCart;
    }

    [HttpPost("/carts/add-to-cart")]
    public async Task<IActionResult> AddToCart(AddToCartRequest request)
    {
        await _addToCart.Execute(request);
        return Ok("Product Added to Cart!");
    }
}