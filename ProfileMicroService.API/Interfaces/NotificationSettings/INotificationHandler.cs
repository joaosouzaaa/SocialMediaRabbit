using ProfileMicroService.API.Settings.NotificationSettings;

namespace ProfileMicroService.API.Interfaces.NotificationSettings;

public interface INotificationHandler
{
    List<Notification> GetNotifications();
    bool HasNotifications();
    void AddNotification(Notification notification);
}
