using MediatR;
using Orders.Shared.Events;

namespace Shipping.Application.Usecases;

public class AddToCartEventHandler
{
    public Task Handle(CartItemAddedEventDto notification)
    {
        Console.Write("Notification received " + notification.CartId);
        throw new Exception("Can't handle the notification");
        return Task.CompletedTask;
    }
}