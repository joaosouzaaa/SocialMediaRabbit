using FollowerMicroService.API.DataTransferObjects.Follow;
using FollowerMicroService.API.Interfaces.Mappers;
using FollowerMicroService.API.Interfaces.Repositories;
using FollowerMicroService.API.Interfaces.Services;
using MassTransit;

namespace FollowerMicroService.API.Services;

public sealed class FollowService : IFollowService
{
    private readonly IFollowRepository _followRepository;
    private readonly IFollowMapper _followMapper;
    private readonly IPublishEndpoint _publishEndpoint;

    public FollowService(IFollowRepository followRepository, IFollowMapper followMapper,
                         IPublishEndpoint publishEndpoint)
    {
        _followRepository = followRepository;
        _followMapper = followMapper;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<bool> AddAsync(FollowSave followSave)
    {
        var follow = _followMapper.SaveToDomain(followSave);

        var addResult = await _followRepository.AddAsync(follow);

        await _publishEndpoint.Publish(followSave);

        return addResult;
    }
}
