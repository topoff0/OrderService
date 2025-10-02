using OrderService.API.Extensions;
using OrderService.Core.Interfaces.Repositories;
using OrderService.Infrastructure.Extensions.Database;
using OrderService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddOrderServiceSwagger();

// Services
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Database
builder.Services.AddPostgresDbContext();

// Controllers
builder.Services.AddControllers();


// Build
var app = builder.Build();

app.UseOrderServiceSwagger(app.Environment);

await DatabaseExtension.ApplyMigrationsAsync(app.Services);

app.Run();
