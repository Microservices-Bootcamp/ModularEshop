using Orders.Application.UseCases;
using Orders.Application.UseCases.Dtos;

namespace Orders.Application.Contracts;

public interface ICartPublisher
{
    Task Publish(CartItemModified cartItemModified);
}