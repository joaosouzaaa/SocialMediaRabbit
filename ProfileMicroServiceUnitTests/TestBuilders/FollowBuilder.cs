using ProfileMicroService.API.Arguments;
using ProfileMicroService.API.DataTransferObjects.Follow;
using ProfileMicroService.API.Entities;

namespace ProfileMicroServiceUnitTests.TestBuilders;
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
        new(_followerId,
            _followingId);

    public GetAllFollowersArgument GetAllFollowersArgumentBuild() =>
        new()
        {
            FollowingId = _random.Next(),
            PageNumber = _random.Next(),
            PageSize = _random.Next()
        };

    public GetAllFollowersRequest GetAllFollowersRequestBuild() =>
        new()
        {
            FollowingId = _random.Next(),
            PageNumber = _random.Next(),
            PageSize = _random.Next()
        };

    public FollowResponse ResponseBuild() =>
        new()
        {
            Follower = ProfileBuilder.NewObject().ResponseBuild(),
            Id = _random.Next()
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
