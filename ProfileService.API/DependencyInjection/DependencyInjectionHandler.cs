using Microsoft.EntityFrameworkCore;
using ProfileService.API.Data.Repositories;
using ProfileService.API.Interfaces.Mappers;
using ProfileService.API.Interfaces.Repositories;
using ProfileService.API.Mappers;
using UserService.API.Data.DatabaseContexts;

namespace ProfileService.API.DependencyInjection;

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

        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<IProfileMapper, ProfileMapper>();
    }
}
