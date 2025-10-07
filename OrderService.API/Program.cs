using FluentValidation;
using FluentValidation.AspNetCore;
using OrderService.API.Extensions;
using OrderService.API.Extensions.UseMiddlewares;
using OrderService.Core.Interfaces.Repositories;
using OrderService.Core.Interfaces.Services;
using OrderService.Infrastructure.Extensions.Database;
using OrderService.Infrastructure.Extensions.Messaging;
using OrderService.Infrastructure.Repositories;
using OrderService.Services.Validators.CreateDtos;
using OrderService.Services.WithCustomer;
using OrderService.Services.WithOrder;

var builder = WebApplication.CreateBuilder(args);

// ============ Swagger =============
builder.Services.AddOrderServiceSwagger();

// ============ Services ============
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<ICustomerService, CustomerModule>();
builder.Services.AddScoped<IOrderService, OrderModule>();

// ============ Fluent validation ============
builder.Services.AddFluentValidationAutoValidation();
// Add all validators (scan full assembly) ->
builder.Services.AddValidatorsFromAssemblyContaining<CreateCustomerDtoValidator>();

// ============ Kafka ==================
builder.Services.AddKafka();

// ============ Database ===============
builder.Services.AddPostgresDbContext();

// ============ Controllers ============
builder.Services.AddControllers();


// ============ Build ==================
var app = builder.Build();

app.UseCustomExceptionMiddleware();

app.UseOrderServiceSwagger(app.Environment);

await DatabaseExtension.ApplyMigrationsAsync(app.Services);

app.MapControllers();

app.Run();
