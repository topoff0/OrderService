using OrderService.API.Extensions;
using OrderService.API.Extensions.UseMiddlewares;
using OrderService.Core.Interfaces.Repositories;
using OrderService.Core.Interfaces.Services;
using OrderService.Infrastructure.Extensions.Database;
using OrderService.Infrastructure.Repositories;
using OrderService.Services.WithCustomer;
using OrderService.Services.WithOrder;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddOrderServiceSwagger();

// Services
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<ICustomerService, CustomerModule>();
builder.Services.AddScoped<IOrderService, OrderModule>();

// Database
builder.Services.AddPostgresDbContext();

// Controllers
builder.Services.AddControllers();


// ======== Build ========
var app = builder.Build();

app.UseCustomExceptionMiddleware();

app.UseOrderServiceSwagger(app.Environment);

await DatabaseExtension.ApplyMigrationsAsync(app.Services);

app.MapControllers();

app.Run();
