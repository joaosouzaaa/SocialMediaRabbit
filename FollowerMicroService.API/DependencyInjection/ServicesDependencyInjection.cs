using FollowerMicroService.API.Interfaces.Services;
using FollowerMicroService.API.Services;

namespace FollowerMicroService.API.DependencyInjection;

public static class ServicesDependencyInjection
{
    public static void AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IFollowService, FollowService>();
    }
}
