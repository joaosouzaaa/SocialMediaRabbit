using NotificationMicroservice.API.Entities;
using NotificationMicroservice.API.Mappers;
using NotificationMicroserviceUnitTests.TestBuilders;

namespace NotificationMicroserviceUnitTests.MappersTests;
public sealed class NotificationMapperTests
{
    private readonly NotificationMapper _notificationMapper;

    public NotificationMapperTests()
    {
        _notificationMapper = new NotificationMapper();
    }

    [Fact]
    public void DomainListToResponseList_SuccessfulScenario()
    {
        // A
        var notificationList = new List<Notification>()
        {
            NotificationBuilder.DomainBuild(),
            NotificationBuilder.DomainBuild()
        };

        // A
        var notificationResponseListResult = _notificationMapper.DomainListToResponseList(notificationList);

        // A
        Assert.Equal(notificationResponseListResult.Count, notificationList.Count);

    }
}
