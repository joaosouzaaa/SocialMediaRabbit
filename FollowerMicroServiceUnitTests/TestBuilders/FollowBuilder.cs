using FollowerMicroService.API.DataTransferObjects.Follow;
using FollowerMicroService.API.Entities;

namespace FollowerMicroServiceUnitTests.TestBuilders;
public sealed class FollowBuilder
{
    private int _followerId = 9;
    private int _followingId = 123;

    public static FollowBuilder NewObject() =>
        new();

    public Follow DomainBuild() =>
        new()
        {
            FollowerId = _followerId,
            FollowingId = _followingId,
            Id = 123
        };

    public FollowSave SaveBuild() =>
        new()
        {
            FollowerId = _followerId,
            FollowingId = _followingId
        };
}
