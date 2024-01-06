using FollowerMicroService.API.Data.Repositories;
using FollowerMicroService.API.Interfaces.Repositories;

namespace FollowerMicroService.API.DependencyInjection;

public static class RepositoriesDependencyInjection
{
    public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IFollowRepository, FollowRepository>();
    }
}
