using FollowerMicroService.API.Mappers;
using FollowerMicroServiceUnitTests.TestBuilders;

namespace FollowerMicroServiceUnitTests.MappersTests;
public sealed class FollowMapperTests
{
    private readonly FollowMapper _followMapper;

    public FollowMapperTests()
    {
        _followMapper = new FollowMapper();
    }

    [Fact]
    public void SaveToDomain_SuccessfulScenario()
    {
        // A
        var followSave = FollowBuilder.NewObject().SaveBuild();

        // A
        var followResult = _followMapper.SaveToDomain(followSave);

        // A
        Assert.Equal(followResult.FollowerId, followSave.FollowerId);
        Assert.Equal(followResult.FollowingId, followSave.FollowingId);
    }
}
