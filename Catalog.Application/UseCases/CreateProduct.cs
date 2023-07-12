using Catalog.Application.Dtos;
using Catalog.Domain.Contracts;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions;

namespace Catalog.Application.UseCases;

public class CreateProduct
{
    private readonly IProductRepository _productRepository;

    public CreateProduct(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Execute(CreateProductRequest request)
    {
        if (request.SellingPrice == 0 || request.CostPrice == 0 || request.SellingPrice < request.CostPrice)
            throw new PriceException();

        // Convert to Product domain model
        var product = Product.CreateNew(new Sku(request.Sku), request.Name, request.CategoryId, request.Description,
            request.CostPrice,
            request.SellingPrice, request.Count);
        await _productRepository.Add(product);
    }
}