using FollowerMicroService.API.DataTransferObjects.Follow;
using FollowerMicroService.API.Entities;

namespace FollowerMicroServiceUnitTests.TestBuilders;
public sealed class FollowBuilder
{
    private static readonly Random _random = new();
    private int _followerId = _random.Next();
    private int _followingId = _random.Next();

    public static FollowBuilder NewObject() =>
        new();

    public Follow DomainBuild() =>
        new()
        {
            FollowerId = _followerId,
            FollowingId = _followingId,
            Id = _random.Next()
        };

    public FollowSave SaveBuild() =>
        new()
        {
            FollowerId = _followerId,
            FollowingId = _followingId
        };

    public FollowBuilder WithFollowerId(int followerId)
    {
        _followerId = followerId;

        return this;
    }

    public FollowBuilder WithFollowingId(int followingId)
    {
        _followingId = followingId;

        return this;
    }
}
