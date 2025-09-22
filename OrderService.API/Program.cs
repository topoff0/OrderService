using Microsoft.OpenApi.Models;
using OrderService.Infrastructure.Extensions.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Order Service API",
        Version = "v1"
    });
});

builder.Services.AddPostgresDbContext();
builder.Services.AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API v1");
        c.RoutePrefix = string.Empty;
    });
}

await DatabaseExtension.ApplyMigrationsAsync(app.Services);

app.Run();

