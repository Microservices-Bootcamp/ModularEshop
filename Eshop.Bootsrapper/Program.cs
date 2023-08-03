using Authentication.API;
using Catalog.API;
using Convey;
using Convey.MessageBrokers.RabbitMQ;
using Orders.Api;
using Shipping.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthenticationModule(builder.Configuration)
    .AddCatalogModule()
    .AddOrderModule()
    .AddShippingModule()
    .AddConvey().AddRabbitMq();

AppDomain.CurrentDomain.GetAssemblies().ToList().ForEach(
    assembly => builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly)));

builder.Services.AddControllers();

var app = builder.Build();
app.UseShippingModule();
app.MapGet("/", () => "Modular Eshop!");
app.MapControllers();
app.Run();