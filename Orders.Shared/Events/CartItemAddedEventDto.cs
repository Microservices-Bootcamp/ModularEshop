using Convey.MessageBrokers;
using MediatR;

namespace Orders.Shared.Events;

[Message("carts", "carts.cartItemAdded", "shipping.cartItemAdded")]
public record CartItemAddedEventDto(Guid CartId);