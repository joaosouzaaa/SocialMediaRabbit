using ProfileMicroService.API.Data.Repositories;
using ProfileMicroService.API.Interfaces.Repositories;

namespace ProfileMicroService.API.DependencyInjection;

public static class RepositoriesDependencyInjection
{
    public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IProfileRepository, ProfileRepository>();
    }
}
