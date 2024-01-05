using ProfileMicroService.API.Interfaces.Services;
using ProfileMicroService.API.Services;

namespace ProfileMicroService.API.DependencyInjection;

public static class ServicesDependencyInjection
{
    public static void AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IProfileService, ProfileService>();
    }
}
