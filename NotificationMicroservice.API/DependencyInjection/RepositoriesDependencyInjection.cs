using NotificationMicroservice.API.Data.Repositories;
using NotificationMicroservice.API.Interfaces.Repositories;

namespace NotificationMicroservice.API.DependencyInjection;

public static class RepositoriesDependencyInjection
{
    public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationRepository, NotificationRepository>();
    }
}
