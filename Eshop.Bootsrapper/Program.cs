using System.Reflection;
using Authentication.API;
using Catalog.API;
using Orders.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCatalogModule()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>())
    .AddAuthenticationModule(builder.Configuration)
    .AddOrderModule();
builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/", () => "Modular Eshop!");
app.MapControllers();
app.Run();