using NotificationMicroservice.API.Enums;

namespace NotificationMicroservice.API.Entities;

public sealed class Notification
{
    public int Id { get; set; }
    public string Message { get; set; }
    public ENotificationType NotificationType { get; set; }
    public int UserId { get; set; }
}
