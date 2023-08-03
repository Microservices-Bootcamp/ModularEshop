using Convey.MessageBrokers.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Orders.Shared.Events;
using Shipping.Application;
using Shipping.Application.Usecases;

namespace Shipping.Api;

public static class Extensions
{
    public static IServiceCollection AddShippingModule(this IServiceCollection services)
    {
        services.AddApplication();
        return services;
    }

    public static IApplicationBuilder UseShippingModule(this IApplicationBuilder app)
    {
        app.UseRabbitMq().Subscribe<CartItemAddedEventDto>(async (serviceProvider, message, context) =>
        {
            await serviceProvider.GetRequiredService<AddToCartEventHandler>().Handle(message);
        });
        return app;
    }
}