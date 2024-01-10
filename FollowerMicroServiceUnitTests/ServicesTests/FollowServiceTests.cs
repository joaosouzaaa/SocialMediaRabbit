using FollowerMicroService.API.DataTransferObjects.Follow;
using FollowerMicroService.API.Entities;
using FollowerMicroService.API.Interfaces.Mappers;
using FollowerMicroService.API.Interfaces.NotificationSettings;
using FollowerMicroService.API.Interfaces.Repositories;
using FollowerMicroService.API.Services;
using FollowerMicroService.API.Settings.NotificationSettings;
using FollowerMicroServiceUnitTests.TestBuilders;
using MassTransit;
using Moq;

namespace FollowerMicroServiceUnitTests.ServicesTests;
public sealed class FollowServiceTests
{
    private readonly Mock<IFollowRepository> _followRepositoryMock;
    private readonly Mock<IFollowMapper> _followMapperMock;
    private readonly Mock<INotificationHandler> _notificationHandlerMock;
    private readonly Mock<IPublishEndpoint> _publishEndpointMock;
    private readonly FollowService _followService;

    public FollowServiceTests()
    {
        _followRepositoryMock = new Mock<IFollowRepository>();
        _followMapperMock = new Mock<IFollowMapper>();
        _notificationHandlerMock = new Mock<INotificationHandler>();
        _publishEndpointMock = new Mock<IPublishEndpoint>();
        _followService = new FollowService(_followRepositoryMock.Object, _followMapperMock.Object, _notificationHandlerMock.Object,
            _publishEndpointMock.Object);
    }

    [Fact]
    public async Task AddAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var followSave = FollowBuilder.NewObject().WithFollowerId(123).WithFollowingId(9).SaveBuild();

        var follow = FollowBuilder.NewObject().DomainBuild();
        _followMapperMock.Setup(f => f.SaveToDomain(It.IsAny<FollowSave>()))
            .Returns(follow);

        _publishEndpointMock.Setup(p => p.Publish(It.IsAny<FollowSave>(), It.IsAny<CancellationToken>()));

        _followRepositoryMock.Setup(f => f.AddAsync(It.IsAny<Follow>()))
            .ReturnsAsync(true);

        // A
        var addResult = await _followService.AddAsync(followSave);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<Notification>()), Times.Never());
        _followMapperMock.Verify(f => f.SaveToDomain(It.IsAny<FollowSave>()), Times.Once());
        _publishEndpointMock.Verify(p => p.Publish(It.IsAny<FollowSave>(), It.IsAny<CancellationToken>()), Times.Once());
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
        _followMapperMock.Verify(f => f.SaveToDomain(It.IsAny<FollowSave>()), Times.Never());
        _publishEndpointMock.Verify(p => p.Publish(It.IsAny<FollowSave>(), It.IsAny<CancellationToken>()), Times.Never());
        _followRepositoryMock.Verify(f => f.AddAsync(It.IsAny<Follow>()), Times.Never());

        Assert.False(addResult);
    }
}
