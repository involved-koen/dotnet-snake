using Koen.DotNet.Snake.Core.Domain;
using Koen.DotNet.Snake.Infrastructure.DataAccess.EF;
using Koen.DotNet.Snake.Infrastructure.DataAccess.EF.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Koen.DotNet.Snake.Infrastructure.Identity;

public static class IdentityServicesRegistration
{
    public static IdentityBuilder AddSnakeIdentityServices(this IServiceCollection services)
    {
        return services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<SnakeDbContext>();
    }
}