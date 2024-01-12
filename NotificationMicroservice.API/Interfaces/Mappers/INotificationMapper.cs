using NotificationMicroservice.API.DataTransferObjects.Notification;
using NotificationMicroservice.API.Entities;

namespace NotificationMicroservice.API.Interfaces.Mappers;

public interface INotificationMapper
{
    List<NotificationResponse> DomainListToResponseList(List<Notification> notificationList);
}
