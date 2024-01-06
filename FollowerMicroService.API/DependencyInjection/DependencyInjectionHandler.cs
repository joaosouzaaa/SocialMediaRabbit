using FollowerMicroService.API.Data.DatabaseContexts;
using FollowerMicroService.API.Factories;
using Microsoft.EntityFrameworkCore;

namespace FollowerMicroService.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();

        services.AddDbContext<FollowerDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString());
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        services.AddRepositoriesDependencyInjection();
    }
}
