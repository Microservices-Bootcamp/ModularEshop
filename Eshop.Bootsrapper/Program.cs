using System.Reflection;
using Authentication.API;
using Catalog.API;
using Orders.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCatalogModule()
    .AddAuthenticationModule(builder.Configuration)
    .AddOrderModule();
AppDomain.CurrentDomain.GetAssemblies().ToList().ForEach(
    assembly => builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly)));
builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/", () => "Modular Eshop!");
app.MapControllers();
app.Run();