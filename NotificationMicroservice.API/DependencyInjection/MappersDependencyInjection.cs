using NotificationMicroservice.API.Interfaces.Mappers;
using NotificationMicroservice.API.Mappers;

namespace NotificationMicroservice.API.DependencyInjection;

public static class MappersDependencyInjection
{
    public static void AddMappersDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationMapper, NotificationMapper>();
    }
}
