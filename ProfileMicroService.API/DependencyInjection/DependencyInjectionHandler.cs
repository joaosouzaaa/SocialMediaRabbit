using Microsoft.EntityFrameworkCore;
using ProfileMicroService.API.Data.DatabaseContexts;

namespace ProfileMicroService.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjectionHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProfileDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("LocalConnection"));
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        services.AddCorsDependencyInjection();
        services.AddSettingsDependencyInjection();
        services.AddFiltersDependencyInjection();
        services.AddRepositoriesDependencyInjection();
        services.AddMappersDependencyInjection();
        services.AddValidatorsDependencyInjection();
        services.AddServicesDependencyInjection();
    }
}
