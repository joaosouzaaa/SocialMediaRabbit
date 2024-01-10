using FollowerMicroService.API.DataTransferObjects.Follow;
using FollowerMicroService.API.Interfaces.Mappers;
using FollowerMicroService.API.Interfaces.NotificationSettings;
using FollowerMicroService.API.Interfaces.Repositories;
using FollowerMicroService.API.Interfaces.Services;
using FollowerMicroService.API.Settings.NotificationSettings;
using MassTransit;

namespace FollowerMicroService.API.Services;

public sealed class FollowService : IFollowService
{
    private readonly IFollowRepository _followRepository;
    private readonly IFollowMapper _followMapper;
    private readonly INotificationHandler _notificationHandler;
    private readonly IPublishEndpoint _publishEndpoint;

    public FollowService(IFollowRepository followRepository, IFollowMapper followMapper,
                         INotificationHandler notificationHandler, IPublishEndpoint publishEndpoint)
    {
        _followRepository = followRepository;
        _followMapper = followMapper;
        _notificationHandler = notificationHandler;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<bool> AddAsync(FollowSave followSave)
    {
        if(IsInvalidFollow(followSave))
            return AddInvalidFollowNotification();

        var follow = _followMapper.SaveToDomain(followSave);

        var addResult = await _followRepository.AddAsync(follow);

        await _publishEndpoint.Publish(followSave);

        return addResult;
    }

    private static bool IsInvalidFollow(FollowSave followSave) =>
        followSave.FollowerId == followSave.FollowingId;

    private bool AddInvalidFollowNotification()
    {
        _notificationHandler.AddNotification(new Notification()
        {
            Key = "Invalid follow",
            Message = "The follower id can't be the same as the following id."
        });

        return false;
    }
}
