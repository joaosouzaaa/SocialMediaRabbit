using ProfileMicroService.API.DataTransferObjects.Follow;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Interfaces.Mappers;
using ProfileMicroService.API.Interfaces.NotificationSettings;
using ProfileMicroService.API.Interfaces.Repositories;
using ProfileMicroService.API.Services;
using ProfileMicroService.API.Settings.NotificationSettings;
using ProfileMicroServiceUnitTests.TestBuilders;
using MassTransit;
using Moq;
using ProfileMicroService.API.Interfaces.Services;
using ProfileMicroService.API.Settings.PaginationSettings;
using ProfileMicroService.API.Arguments;
using Contracts;
using System.Linq.Expressions;

namespace ProfileMicroServiceUnitTests.ServicesTests;
public sealed class FollowServiceTests
{
    private readonly Mock<IFollowRepository> _followRepositoryMock;
    private readonly Mock<IFollowMapper> _followMapperMock;
    private readonly Mock<INotificationHandler> _notificationHandlerMock;
    private readonly Mock<IProfileExistsServiceFacade> _profileExistsServiceFacadeMock;
    private readonly Mock<IPublishEndpoint> _publishEndpointMock;
    private readonly FollowService _followService;

    public FollowServiceTests()
    {
        _followRepositoryMock = new Mock<IFollowRepository>();
        _followMapperMock = new Mock<IFollowMapper>();
        _notificationHandlerMock = new Mock<INotificationHandler>();
        _profileExistsServiceFacadeMock = new Mock<IProfileExistsServiceFacade>();
        _publishEndpointMock = new Mock<IPublishEndpoint>();
        _followService = new FollowService(_followRepositoryMock.Object, _followMapperMock.Object, _notificationHandlerMock.Object,
            _profileExistsServiceFacadeMock.Object, _publishEndpointMock.Object);
    }

    [Fact]
    public async Task AddAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var followSave = FollowBuilder.NewObject().WithFollowerId(123).WithFollowingId(9).SaveBuild();

        _profileExistsServiceFacadeMock.SetupSequence(p => p.ExistsAsync(It.IsAny<int>()))
            .ReturnsAsync(true)
            .ReturnsAsync(true);

        _followRepositoryMock.Setup(f => f.AnyAsync(It.IsAny<Expression<Func<Follow, bool>>>()))
            .ReturnsAsync(false);

        var follow = FollowBuilder.NewObject().DomainBuild();
        _followMapperMock.Setup(f => f.SaveToDomain(It.IsAny<FollowSave>()))
            .Returns(follow);

        _publishEndpointMock.Setup(p => p.Publish(It.IsAny<FollowCreatedEvent>(), It.IsAny<CancellationToken>()));

        _followRepositoryMock.Setup(f => f.AddAsync(It.IsAny<Follow>()))
            .ReturnsAsync(true);

        // A
        var addResult = await _followService.AddAsync(followSave);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<Notification>()), Times.Never());
        _profileExistsServiceFacadeMock.Verify(p => p.ExistsAsync(It.IsAny<int>()), Times.Exactly(2));
        _followRepositoryMock.Verify(f => f.AnyAsync(It.IsAny<Expression<Func<Follow, bool>>>()), Times.Once());
        _followMapperMock.Verify(f => f.SaveToDomain(It.IsAny<FollowSave>()), Times.Once());
        _publishEndpointMock.Verify(p => p.Publish(It.IsAny<FollowCreatedEvent>(), It.IsAny<CancellationToken>()), Times.Once());
        _followRepositoryMock.Verify(f => f.AddAsync(It.IsAny<Follow>()), Times.Once());

        Assert.True(addResult);
    }

    [Fact]
    public async Task AddAsync_FollowerIdEqualsFollowingId_ReturnsFalse()
    {
        // A
        var followSave = FollowBuilder.NewObject().WithFollowerId(9).WithFollowingId(9).SaveBuild();

        _notificationHandlerMock.Setup(n => n.AddNotification(It.IsAny<Notification>()));

        // A
        var addResult = await _followService.AddAsync(followSave);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<Notification>()), Times.Once());
        _profileExistsServiceFacadeMock.Verify(p => p.ExistsAsync(It.IsAny<int>()), Times.Never());
        _followRepositoryMock.Verify(f => f.AnyAsync(It.IsAny<Expression<Func<Follow, bool>>>()), Times.Never());
        _followMapperMock.Verify(f => f.SaveToDomain(It.IsAny<FollowSave>()), Times.Never());
        _publishEndpointMock.Verify(p => p.Publish(It.IsAny<FollowCreatedEvent>(), It.IsAny<CancellationToken>()), Times.Never());
        _followRepositoryMock.Verify(f => f.AddAsync(It.IsAny<Follow>()), Times.Never());

        Assert.False(addResult);
    }

    [Fact]
    public async Task AddAsync_ProfileDoesNotExist_ReturnsFalse()
    {
        // A
        var followSave = FollowBuilder.NewObject().WithFollowerId(1239).WithFollowingId(9).SaveBuild();

        _profileExistsServiceFacadeMock.SetupSequence(p => p.ExistsAsync(It.IsAny<int>()))
            .ReturnsAsync(true)
            .ReturnsAsync(false);

        _notificationHandlerMock.Setup(n => n.AddNotification(It.IsAny<Notification>()));

        // A
        var addResult = await _followService.AddAsync(followSave);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<Notification>()), Times.Once());
        _profileExistsServiceFacadeMock.Verify(p => p.ExistsAsync(It.IsAny<int>()), Times.Exactly(2));
        _followRepositoryMock.Verify(f => f.AnyAsync(It.IsAny<Expression<Func<Follow, bool>>>()), Times.Never());
        _followMapperMock.Verify(f => f.SaveToDomain(It.IsAny<FollowSave>()), Times.Never());
        _publishEndpointMock.Verify(p => p.Publish(It.IsAny<FollowCreatedEvent>(), It.IsAny<CancellationToken>()), Times.Never());
        _followRepositoryMock.Verify(f => f.AddAsync(It.IsAny<Follow>()), Times.Never());

        Assert.False(addResult);
    }

    [Fact]
    public async Task AddAsync_FollowAlreadyExists_ReturnsFalse()
    {
        // A
        var followSave = FollowBuilder.NewObject().WithFollowerId(123).WithFollowingId(9).SaveBuild();

        _profileExistsServiceFacadeMock.SetupSequence(p => p.ExistsAsync(It.IsAny<int>()))
            .ReturnsAsync(true)
            .ReturnsAsync(true);

        _followRepositoryMock.Setup(f => f.AnyAsync(It.IsAny<Expression<Func<Follow, bool>>>()))
            .ReturnsAsync(true);

        // A
        var addResult = await _followService.AddAsync(followSave);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<Notification>()), Times.Once());
        _profileExistsServiceFacadeMock.Verify(p => p.ExistsAsync(It.IsAny<int>()), Times.Exactly(2));
        _followRepositoryMock.Verify(f => f.AnyAsync(It.IsAny<Expression<Func<Follow, bool>>>()), Times.Once());
        _followMapperMock.Verify(f => f.SaveToDomain(It.IsAny<FollowSave>()), Times.Never());
        _publishEndpointMock.Verify(p => p.Publish(It.IsAny<FollowCreatedEvent>(), It.IsAny<CancellationToken>()), Times.Never());
        _followRepositoryMock.Verify(f => f.AddAsync(It.IsAny<Follow>()), Times.Never());

        Assert.False(addResult);
    }

    [Fact]
    public async Task GetAllFollowsByFollowingIdPaginatedAsync_SuccessfulScenario_ReturnsEntityPageList()
    {
        // A
        var getAllFollowersRequest = FollowBuilder.NewObject().GetAllFollowersRequestBuild();

        var getAllFollowers = FollowBuilder.NewObject().GetAllFollowersArgumentBuild();
        _followMapperMock.Setup(f => f.GetAllFollowersRequestToDomain(It.IsAny<GetAllFollowersRequest>()))
            .Returns(getAllFollowers);

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
        _followRepositoryMock.Setup(f => f.GetAllFollowsByFollowingIdPaginatedAsync(It.IsAny<GetAllFollowersArgument>()))
            .ReturnsAsync(followPageList);

        var followResponseList = new List<FollowResponse>()
        {
            FollowBuilder.NewObject().ResponseBuild(),
            FollowBuilder.NewObject().ResponseBuild()
        };
        var followResponsePageList = new PageList<FollowResponse>()
        {
            CurrentPage = 123,
            PageSize = 123,
            Result = followResponseList,
            TotalCount = 9,
            TotalPages = 10
        };
        _followMapperMock.Setup(f => f.DomainPageListToResponsePageList(It.IsAny<PageList<Follow>>()))
            .Returns(followResponsePageList);

        // A
        var followResponsePageListResult = await _followService.GetAllFollowsByFollowingIdPaginatedAsync(getAllFollowersRequest);

        // A
        Assert.Equal(followResponsePageListResult.Result.Count, followResponsePageList.Result.Count);
    }

    [Fact]
    public async Task DeleteAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        int id = 123;

        _followRepositoryMock.Setup(f => f.AnyAsync(It.IsAny<Expression<Func<Follow, bool>>>()))
            .ReturnsAsync(true);

        _followRepositoryMock.Setup(f => f.DeleteAsync(It.IsAny<int>()))
            .ReturnsAsync(true);

        // A
        var deleteResult = await _followService.DeleteAsync(id);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<Notification>()), Times.Never());
        _followRepositoryMock.Verify(f => f.DeleteAsync(It.IsAny<int>()), Times.Once());

        Assert.True(deleteResult);
    }

    [Fact]
    public async Task DeleteAsync_FollowDoesNotExist_ReturnsFalse()
    {
        // A
        int id = 123;

        _followRepositoryMock.Setup(f => f.AnyAsync(It.IsAny<Expression<Func<Follow, bool>>>()))
            .ReturnsAsync(false);

        _notificationHandlerMock.Setup(n => n.AddNotification(It.IsAny<Notification>()));

        // A
        var deleteResult = await _followService.DeleteAsync(id);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<Notification>()), Times.Once());
        _followRepositoryMock.Verify(f => f.DeleteAsync(It.IsAny<int>()), Times.Never());

        Assert.False(deleteResult);
    }
}
