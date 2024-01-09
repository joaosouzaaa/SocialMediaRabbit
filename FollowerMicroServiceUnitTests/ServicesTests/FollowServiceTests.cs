using FollowerMicroService.API.DataTransferObjects.Follow;
using FollowerMicroService.API.Entities;
using FollowerMicroService.API.Interfaces.Mappers;
using FollowerMicroService.API.Interfaces.Repositories;
using FollowerMicroService.API.Services;
using FollowerMicroServiceUnitTests.TestBuilders;
using MassTransit;
using Moq;

namespace FollowerMicroServiceUnitTests.ServicesTests;
public sealed class FollowServiceTests
{
    private readonly Mock<IFollowRepository> _followRepositoryMock;
    private readonly Mock<IFollowMapper> _followMapperMock;
    private readonly Mock<IPublishEndpoint> _publishEndpointMock;
    private readonly FollowService _followService;

    public FollowServiceTests()
    {
        _followRepositoryMock = new Mock<IFollowRepository>();
        _followMapperMock = new Mock<IFollowMapper>();
        _publishEndpointMock = new Mock<IPublishEndpoint>();
        _followService = new FollowService(_followRepositoryMock.Object, _followMapperMock.Object, _publishEndpointMock.Object);
    }

    [Fact]
    public async Task AddAsync_SuccessfulScenario()
    {
        // A
        var followSave = FollowBuilder.NewObject().SaveBuild();

        var follow = FollowBuilder.NewObject().DomainBuild();
        _followMapperMock.Setup(f => f.SaveToDomain(It.IsAny<FollowSave>()))
            .Returns(follow);

        _publishEndpointMock.Setup(p => p.Publish(It.IsAny<FollowSave>(), It.IsAny<CancellationToken>()));

        _followRepositoryMock.Setup(f => f.AddAsync(It.IsAny<Follow>()))
            .ReturnsAsync(true);

        // A
        var addResult = await _followService.AddAsync(followSave);

        // A
        _publishEndpointMock.Verify(p => p.Publish(It.IsAny<FollowSave>(), It.IsAny<CancellationToken>()), Times.Once());
        _followRepositoryMock.Verify(f => f.AddAsync(It.IsAny<Follow>()), Times.Once());

        Assert.True(addResult);
    }
}
