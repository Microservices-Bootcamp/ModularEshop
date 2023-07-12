using Authentication.API;
using Catalog.API;
using Orders.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCatalogModule()
    .AddAuthenticationModule(builder.Configuration)
    .AddOrderModule();
builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/", () => "Modular Eshop!");
app.MapControllers();
app.Run();