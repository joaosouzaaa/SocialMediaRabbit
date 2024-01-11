using Moq;
using ProfileMicroService.API.DataTransferObjects.Follow;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Interfaces.Mappers;
using ProfileMicroService.API.Mappers;
using ProfileMicroService.API.Settings.PaginationSettings;
using ProfileMicroServiceUnitTests.TestBuilders;

namespace ProfileMicroServiceUnitTests.MappersTests;
public sealed class FollowMapperTests
{
    private readonly Mock<IProfileMapper> _profileMapperMock;
    private readonly FollowMapper _followMapper;

    public FollowMapperTests()
    {
        _profileMapperMock = new Mock<IProfileMapper>();
        _followMapper = new FollowMapper(_profileMapperMock.Object);
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

    [Fact]
    public void GetAllFollowersRequestToDomain_SuccessfulScenario()
    {
        // A
        var getAllFollowersRequest = FollowBuilder.NewObject().GetAllFollowersRequestBuild();

        // A
        var getAllFollowersArgumentResult = _followMapper.GetAllFollowersRequestToDomain(getAllFollowersRequest);

        // A
        Assert.Equal(getAllFollowersArgumentResult.FollowingId, getAllFollowersRequest.FollowingId);
        Assert.Equal(getAllFollowersArgumentResult.PageNumber, getAllFollowersRequest.PageNumber);
        Assert.Equal(getAllFollowersArgumentResult.PageSize, getAllFollowersRequest.PageSize);

    }

    [Fact]
    public void DomainPageListToResponsePageList_SuccessfulScenario()
    {
        // A
        var followList = new List<Follow>()
        {
            FollowBuilder.NewObject().DomainBuild(),
            FollowBuilder.NewObject().DomainBuild()
        };
        var followPageList = new PageList<Follow>()
        {
            CurrentPage = 123,
            PageSize = 123,
            Result = followList,
            TotalCount = 9,
            TotalPages = 10
        };

        var profileResponse = ProfileBuilder.NewObject().ResponseBuild();
        _profileMapperMock.Setup(p => p.DomainToResponse(It.IsAny<Profile>()))
            .Returns(profileResponse);

        // A
        var followResponsePageListResult = _followMapper.DomainPageListToResponsePageList(followPageList);

        // A
        Assert.Equal(followResponsePageListResult.CurrentPage, followPageList.CurrentPage);
        Assert.Equal(followResponsePageListResult.PageSize, followPageList.PageSize);
        Assert.Equal(followResponsePageListResult.Result.Count, followPageList.Result.Count);
        Assert.Equal(followResponsePageListResult.TotalCount, followPageList.TotalCount);
        Assert.Equal(followResponsePageListResult.TotalPages, followPageList.TotalPages);
    }
}
