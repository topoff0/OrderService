
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OrderService.Infrastructure.Data
{
    // Class to run ef migrations commands in terminal
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var envPath = Path.Combine(AppContext.BaseDirectory, "../../../..", ".env");

            DotNetEnv.Env.Load(envPath);

            var user = Environment.GetEnvironmentVariable("POSTGRES_USER");
            var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
            var database = Environment.GetEnvironmentVariable("POSTGRES_DB");
            var port = Environment.GetEnvironmentVariable("POSTGRES_PORT");
            var host = Environment.GetEnvironmentVariable("POSTGRES_HOST");

            string connectionString = $"Host={host};Port={port};Username={user};Password={password};Database={database};";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}