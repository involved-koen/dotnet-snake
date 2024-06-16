using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Koen.DotNet.Snake.Infrastructure.DataAccess;

public static class DataAccessServiceRegistration
{
    public static void AddSnakeDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database") ??
                               throw new InvalidOperationException("Connection string 'Database' not found.");

        services.AddDbContext<SnakeDbContext>(options => options.UseSqlServer(connectionString));
    }
}