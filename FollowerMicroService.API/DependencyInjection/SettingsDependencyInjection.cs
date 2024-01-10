using FollowerMicroService.API.Interfaces.NotificationSettings;
using FollowerMicroService.API.Settings.NotificationSettings;

namespace FollowerMicroService.API.DependencyInjection;

public static class SettingsDependencyInjection
{
    public static void AddSettingsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();
    }
}
