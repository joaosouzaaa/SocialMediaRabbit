using NotificationMicroservice.API.DataTransferObjects.Notification;

namespace NotificationMicroservice.API.Interfaces.Services;

public interface INotificationService
{
    Task<List<NotificationResponse>> GetAllByUserIdAsync(int userId);
}
