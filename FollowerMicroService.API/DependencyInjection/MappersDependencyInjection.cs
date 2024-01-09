using FollowerMicroService.API.Interfaces.Mappers;
using FollowerMicroService.API.Mappers;

namespace FollowerMicroService.API.DependencyInjection;

public static class MappersDependencyInjection
{
    public static void AddMappersDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IFollowMapper, FollowMapper>();
    }
}
