
using Microsoft.OpenApi.Models;

namespace OrderService.API.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddOrderServiceSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Order Service API",
                    Version = "v1"
                });
            });
            return services;
        }

        public static IApplicationBuilder UseOrderServiceSwagger(this IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API v1");
                    c.RoutePrefix = string.Empty;
                });
            }
            return app;
        }
    }
}