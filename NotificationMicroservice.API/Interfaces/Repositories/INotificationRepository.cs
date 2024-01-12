using NotificationMicroservice.API.Entities;

namespace NotificationMicroservice.API.Interfaces.Repositories;

public interface INotificationRepository
{
    Task<bool> AddAsync(Notification notification);
    Task<List<Notification>> GetAllByUserId(int userId);
}
