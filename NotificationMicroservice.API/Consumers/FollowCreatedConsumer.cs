using Contracts;
using MassTransit;
using NotificationMicroservice.API.Entities;
using NotificationMicroservice.API.Enums;
using NotificationMicroservice.API.Interfaces.Repositories;

namespace NotificationMicroservice.API.Consumers;

public sealed class FollowCreatedConsumer : IConsumer<FollowCreatedEvent>
{
    private readonly INotificationRepository _notificationRepository;

    public FollowCreatedConsumer(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public Task Consume(ConsumeContext<FollowCreatedEvent> context)
    {
        FollowCreatedEvent message = context.Message;

        _notificationRepository.AddAsync(new Notification()
        {
            Message = $"{message.FollowerId} followed you.",
            NotificationType = ENotificationType.Follow,
            UserId = message.FollowingId
        });

        return Task.CompletedTask;
    }
}
