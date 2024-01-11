using ProfileMicroService.API.Interfaces.Mappers;
using ProfileMicroService.API.Mappers;

namespace ProfileMicroService.API.DependencyInjection;

public static class MappersDependencyInjection
{
    public static void AddMappersDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IFollowMapper, FollowMapper>();
        services.AddScoped<IProfileMapper, ProfileMapper>();
    }
}
