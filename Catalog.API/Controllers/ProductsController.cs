using Catalog.Application.Dtos;
using Catalog.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers;

[Route("/products")]
public class ProductsController : ControllerBase
{
    private readonly CreateProduct _createProduct;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(CreateProduct createProduct, ILogger<ProductsController> logger)
    {
        _createProduct = createProduct;
        _logger = logger;
    }

    public async Task<IActionResult> Post([FromBody] CreateProductRequest product)
    {
        
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values
                .SelectMany(value => value.Errors)
                .Select(error => error.ErrorMessage)
                .ToList();

            return BadRequest(errors);
        }
        _logger.LogInformation("Product with ${ProductName} requested", product.Name);
        await _createProduct.Execute(product);
        return Ok("Product Created..");
    }
}