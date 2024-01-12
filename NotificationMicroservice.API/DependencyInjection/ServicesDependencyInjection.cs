using NotificationMicroservice.API.Interfaces.Services;
using NotificationMicroservice.API.Services;

namespace NotificationMicroservice.API.DependencyInjection;

public static class ServicesDependencyInjection
{
    public static void AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationService, NotificationService>();
    }
}
