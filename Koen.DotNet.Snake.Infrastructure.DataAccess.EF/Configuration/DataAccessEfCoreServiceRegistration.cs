using Koen.DotNet.Snake.Application.Contracts.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Koen.DotNet.Snake.Infrastructure.DataAccess.EF.Configuration;

public static class DataAccessEfCoreServiceRegistration
{
    public static void AddSnakeDataAccessSqlServerServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlServer") ??
                               throw new InvalidOperationException("Connection string 'SqlServer' not found.");

        services.AddDbContext<ISnakeDbContext, SnakeDbContext>(options => options.UseSqlServer(connectionString));
    }
    
    public static void AddSnakeDataAccessCosmosDbServices(this IServiceCollection services, IConfiguration configuration)
    {
        var settings =
            configuration.BindAndValidateConfiguration<CosmosDbSettings, CosmosDbSettingsValidator>("CosmosDbSettings");

        services.AddDbContext<ISnakeDbContext, SnakeDbContext>(options => options.UseCosmos(settings.Endpoint, settings.Key, settings.Database));
    }

    public static async Task EnsureDatabaseCreated(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<SnakeDbContext>();
        await dbContext.Database.EnsureCreatedAsync();
    }
}