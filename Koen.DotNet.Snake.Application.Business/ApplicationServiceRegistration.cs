using Microsoft.Extensions.DependencyInjection;

namespace Koen.DotNet.Snake.Application.Business;

public static class ApplicationServiceRegistration
{
    public static void AddSnakeApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration => { });
    }
}