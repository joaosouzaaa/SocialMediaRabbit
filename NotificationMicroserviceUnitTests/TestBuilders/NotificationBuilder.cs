using NotificationMicroservice.API.DataTransferObjects.Notification;
using NotificationMicroservice.API.Entities;
using NotificationMicroservice.API.Enums;

namespace NotificationMicroserviceUnitTests.TestBuilders;
public static class NotificationBuilder
{
    public static Notification DomainBuild() =>
        new()
        {
            Id = 123,
            Message = "test",
            NotificationType = ENotificationType.Follow,
            UserId = 123
        };

    public static NotificationResponse ResponseBuild() =>
        new()
        {
            Id = 123,
            Message = "TEST",
            NotificationType = "test",
            UserId = 9
        };
}
