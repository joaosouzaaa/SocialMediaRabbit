using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.API.Data.DatabaseContexts;
using NotificationMicroservice.API.Factories;

namespace NotificationMicroservice.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();

        services.AddDbContext<NotificationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString());
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        services.AddMassTransitDependencyInjection(configuration);
        services.AddRepositoriesDependencyInjection();
        services.AddMappersDependencyInjection();
        services.AddServicesDependencyInjection();
    }
}
