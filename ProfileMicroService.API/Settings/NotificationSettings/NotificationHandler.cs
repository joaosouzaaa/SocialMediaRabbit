using ProfileMicroService.API.Interfaces.NotificationSettings;

namespace ProfileMicroService.API.Settings.NotificationSettings;

public sealed class NotificationHandler : INotificationHandler
{
    private readonly List<Notification> _notificationList;

    public NotificationHandler()
    {
        _notificationList = new List<Notification>();
    }

    public List<Notification> GetNotifications() =>
        _notificationList;

    public bool HasNotifications() =>
        _notificationList.Any();

    public void AddNotification(Notification notification) =>
        _notificationList.Add(notification);
}
