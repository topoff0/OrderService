
using OrderService.API.Middlewares;

namespace OrderService.API.Extensions.UseMiddlewares
{
    public static class UseExceptionMiddleware
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}