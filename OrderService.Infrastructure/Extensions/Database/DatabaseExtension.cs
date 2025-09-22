
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.Extensions.Database
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddPostgresDbContext(this IServiceCollection services)
        {
            var envPath = Path.Combine(AppContext.BaseDirectory, "../../../..", ".env");

            DotNetEnv.Env.Load(envPath);

            // Get postgres data from .env
            var user = Environment.GetEnvironmentVariable("POSTGRES_USER");
            var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
            var database = Environment.GetEnvironmentVariable("POSTGRES_DB");
            var port = Environment.GetEnvironmentVariable("POSTGRES_PORT");
            var host = Environment.GetEnvironmentVariable("POSTGRES_HOST");

            string connectionString
                = $"Host={host};Port={port};Username={user};Password={password};Database={database};";

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            return services;
        }

        public static async Task ApplyMigrationsAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await db.Database.MigrateAsync();
        }
    }
}