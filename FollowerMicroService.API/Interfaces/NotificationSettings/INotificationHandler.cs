using FollowerMicroService.API.Settings.NotificationSettings;

namespace FollowerMicroService.API.Interfaces.NotificationSettings;

public interface INotificationHandler
{
    List<Notification> GetNotifications();
    bool HasNotifications();
    void AddNotification(Notification notification);
}
