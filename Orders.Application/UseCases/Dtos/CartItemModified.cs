using MediatR;

namespace Orders.Application.UseCases.Dtos;

public class CartItemModified : INotification
{
    public CartItemModified(Guid id)
    {
        this.CartId = id;
    }

    public Guid CartId { get; set; }
}