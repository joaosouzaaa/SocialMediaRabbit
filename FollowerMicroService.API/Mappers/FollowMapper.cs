using FollowerMicroService.API.DataTransferObjects.Follow;
using FollowerMicroService.API.Entities;
using FollowerMicroService.API.Interfaces.Mappers;

namespace FollowerMicroService.API.Mappers;

public sealed class FollowMapper : IFollowMapper
{
    public Follow SaveToDomain(FollowSave followSave) =>
        new()
        {
            FollowerId = followSave.FollowerId,
            FollowingId = followSave.FollowingId
        };
}
