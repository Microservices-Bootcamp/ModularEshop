using Catalog.Application.Dtos;
using Catalog.Domain.Contracts;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions;

namespace Catalog.Application.UseCases;

public class GetProduct
{
    private readonly IProductRepository _productRepository;

    public GetProduct(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> Execute(string sku)
    {
        return await _productRepository.GetBySku(sku);
    }
}