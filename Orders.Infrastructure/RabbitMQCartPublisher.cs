using Convey.MessageBrokers;
using Orders.Application.Contracts;
using Orders.Application.UseCases.Dtos;
using Orders.Shared.Events;

namespace Orders.Infrastructure;

public class RabbitMQCartPublisher : ICartPublisher
{
    private readonly IBusPublisher _publisher;

    public RabbitMQCartPublisher(IBusPublisher publisher)
    {
        _publisher = publisher;
    }

    public async Task Publish(CartItemModified @event)
    {
        await _publisher.PublishAsync(new CartItemAddedEventDto(@event.CartId));
    }
}