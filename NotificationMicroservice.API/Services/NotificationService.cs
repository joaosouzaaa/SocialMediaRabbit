using NotificationMicroservice.API.DataTransferObjects.Notification;
using NotificationMicroservice.API.Interfaces.Mappers;
using NotificationMicroservice.API.Interfaces.Repositories;
using NotificationMicroservice.API.Interfaces.Services;

namespace NotificationMicroservice.API.Services;

public sealed class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepository;
    private readonly INotificationMapper _notificationMapper;

    public NotificationService(INotificationRepository notificationRepository, INotificationMapper notificationMapper)
    {
        _notificationRepository = notificationRepository;
        _notificationMapper = notificationMapper;
    }


    public async Task<List<NotificationResponse>> GetAllByUserIdAsync(int userId)
    {
        var notificationList = await _notificationRepository.GetAllByUserId(userId);

        return _notificationMapper.DomainListToResponseList(notificationList);
    }
}
