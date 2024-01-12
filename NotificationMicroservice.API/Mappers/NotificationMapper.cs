using NotificationMicroservice.API.DataTransferObjects.Notification;
using NotificationMicroservice.API.Entities;
using NotificationMicroservice.API.Interfaces.Mappers;

namespace NotificationMicroservice.API.Mappers;

public sealed class NotificationMapper : INotificationMapper
{
    public List<NotificationResponse> DomainListToResponseList(List<Notification> notificationList) =>
        notificationList.Select(DomainToResponse).ToList();

    private NotificationResponse DomainToResponse(Notification notification) =>
        new()
        {
            Id = notification.Id,
            Message = notification.Message,
            NotificationType = notification.NotificationType.ToString(),
            UserId = notification.UserId
        };
}
