using ProfileMicroService.API.DataTransferObjects.Follow;
using ProfileMicroService.API.Interfaces.Mappers;
using ProfileMicroService.API.Interfaces.NotificationSettings;
using ProfileMicroService.API.Interfaces.Repositories;
using ProfileMicroService.API.Interfaces.Services;
using ProfileMicroService.API.Settings.NotificationSettings;
using MassTransit;
using ProfileMicroService.API.Enums;
using ProfileMicroService.API.Extensions;
using Contracts;
using ProfileMicroService.API.Settings.PaginationSettings;

namespace ProfileMicroService.API.Services;

public sealed class FollowService : IFollowService
{
    private readonly IFollowRepository _followRepository;
    private readonly IFollowMapper _followMapper;
    private readonly INotificationHandler _notificationHandler;
    private readonly IProfileExistsServiceFacade _profileExistsServiceFacade;
    private readonly IPublishEndpoint _publishEndpoint;

    public FollowService(IFollowRepository followRepository, IFollowMapper followMapper,
                         INotificationHandler notificationHandler, IProfileExistsServiceFacade profileExistsServiceFacade,
                         IPublishEndpoint publishEndpoint)
    {
        _followRepository = followRepository;
        _followMapper = followMapper;
        _notificationHandler = notificationHandler;
        _profileExistsServiceFacade = profileExistsServiceFacade;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<bool> AddAsync(FollowSave followSave)
    {
        if (IsInvalidFollow(followSave))
        {
            _notificationHandler.AddNotification(new Notification()
            {
                Key = "Invalid follow",
                Message = "The follower id can't be the same as the following id."
            });

            return false;
        }

        if (!await ProfilesExist(followSave))
        {
            _notificationHandler.AddNotification(new Notification()
            {
                Key = nameof(EMessage.NotFound),
                Message = EMessage.NotFound.Description().FormatTo("Profile")
            });

            return false;
        }

        if(await _followRepository.AnyAsync(f => f.FollowerId == followSave.FollowerId && f.FollowingId == followSave.FollowingId))
        {
            _notificationHandler.AddNotification(new Notification()
            {
                Key = nameof(EMessage.Exists),
                Message = EMessage.Exists.Description().FormatTo("Follow")
            });

            return false;
        }

        var follow = _followMapper.SaveToDomain(followSave);

        var addResult = await _followRepository.AddAsync(follow);

        await _publishEndpoint.Publish(new FollowCreatedEvent(follow.FollowerId, follow.FollowingId));

        return addResult;
    }

    public async Task<PageList<FollowResponse>> GetAllFollowsByFollowingIdPaginatedAsync(GetAllFollowersRequest getAllFollowersRequest)
    {
        var getAllFollowers = _followMapper.GetAllFollowersRequestToDomain(getAllFollowersRequest);

        var followPageList = await _followRepository.GetAllFollowsByFollowingIdPaginatedAsync(getAllFollowers);

        return _followMapper.DomainPageListToResponsePageList(followPageList);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (!await _followRepository.AnyAsync(p => p.Id == id))
        {
            _notificationHandler.AddNotification(new Notification()
            {
                Key = nameof(EMessage.NotFound),
                Message = EMessage.NotFound.Description().FormatTo("Profile")
            });

            return false;
        }

        return await _followRepository.DeleteAsync(id);
    }

    private static bool IsInvalidFollow(FollowSave followSave) =>
        followSave.FollowerId == followSave.FollowingId;

    private async Task<bool> ProfilesExist(FollowSave followSave) =>
        await _profileExistsServiceFacade.ExistsAsync(followSave.FollowerId)
        && await _profileExistsServiceFacade.ExistsAsync(followSave.FollowingId);
}
