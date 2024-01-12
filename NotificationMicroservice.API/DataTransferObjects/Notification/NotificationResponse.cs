namespace NotificationMicroservice.API.DataTransferObjects.Notification;

public sealed class NotificationResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
    public string NotificationType { get; set; }
    public int UserId { get; set; }
}
