
using System.Net;
using System.Text.Json;
using OrderService.Core.Exceptions;

namespace OrderService.API.Middlewares
{
    public class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
    {
        private readonly ILogger<ExceptionMiddleware> _logger = logger;
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (RecordNotFoundException ex)
            {
                _logger.LogError($"RecordNotFoundException: ${ex.Message}");
                await WriteErrorAsync(
                    context,
                    HttpStatusCode.NotFound,
                    "Not found",
                    "Sorry, we couldn't find data");
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"UnknownException: {ex.Message}\n\n StackTrace: {ex.StackTrace}");
                await WriteErrorAsync(
                    context,
                    HttpStatusCode.InternalServerError,
                    "Internal server error",
                    "Sorry, something went wrong");
            }
        }

        private static async Task WriteErrorAsync
                            (
                                HttpContext context,
                                HttpStatusCode statusCode,
                                string errorTitle,
                                string? errorMessage = null
                            )
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                statusCode,
                errorTitle,
                errorMessage,
                timestamp = DateTime.UtcNow
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}