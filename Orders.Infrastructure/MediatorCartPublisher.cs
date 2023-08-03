using MediatR;
using Orders.Application.Contracts;
using Orders.Application.UseCases.Dtos;
using Orders.Shared.Events;

namespace Orders.Infrastructure;

public class MediatorCartPublisher : ICartPublisher
{
    private readonly IMediator _mediator;

    public MediatorCartPublisher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Publish(CartItemModified @event)
    {
        await _mediator.Publish(new CartItemAddedEventDto(@event.CartId));
    }
}