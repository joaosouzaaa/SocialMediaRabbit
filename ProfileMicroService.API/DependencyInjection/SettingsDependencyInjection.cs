using ProfileMicroService.API.Interfaces.NotificationSettings;
using ProfileMicroService.API.Settings.NotificationSettings;

namespace ProfileMicroService.API.DependencyInjection;

public static class SettingsDependencyInjection
{
    public static void AddSettingsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();

        services.AddValidatorsDependencyInjection();
    }
}
