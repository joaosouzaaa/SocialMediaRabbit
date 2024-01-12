using Moq;
using NotificationMicroservice.API.DataTransferObjects.Notification;
using NotificationMicroservice.API.Entities;
using NotificationMicroservice.API.Interfaces.Mappers;
using NotificationMicroservice.API.Interfaces.Repositories;
using NotificationMicroservice.API.Services;
using NotificationMicroserviceUnitTests.TestBuilders;

namespace NotificationMicroserviceUnitTests.ServicesTests;
public sealed class NotificationServiceTests
{
    private readonly Mock<INotificationRepository> _notificationRepositoryMock;
    private readonly Mock<INotificationMapper> _notificationMapperMock;
    private readonly NotificationService _notificationService;

    public NotificationServiceTests()
    {
        _notificationRepositoryMock = new Mock<INotificationRepository>();
        _notificationMapperMock = new Mock<INotificationMapper>();
        _notificationService = new NotificationService(_notificationRepositoryMock.Object, _notificationMapperMock.Object);
    }

    [Fact]
    public async Task GetAllByUserIdAsync_SuccessfulScenario_ReturnsEntityList()
    {
        // A
        var userId = 123;

        var notificationList = new List<Notification>()
        {
            NotificationBuilder.DomainBuild(),
            NotificationBuilder.DomainBuild()
        };
        _notificationRepositoryMock.Setup(n => n.GetAllByUserId(It.IsAny<int>()))
            .ReturnsAsync(notificationList);

        var notificationResponseList = new List<NotificationResponse>()
        {
            NotificationBuilder.ResponseBuild(),
            NotificationBuilder.ResponseBuild()
        };
        _notificationMapperMock.Setup(n => n.DomainListToResponseList(It.IsAny<List<Notification>>()))
            .Returns(notificationResponseList);

        // A
        var notificationResponseListResult = await _notificationService.GetAllByUserIdAsync(userId);

        // A
        Assert.Equal(notificationResponseListResult.Count, notificationResponseList.Count);
    }
}
