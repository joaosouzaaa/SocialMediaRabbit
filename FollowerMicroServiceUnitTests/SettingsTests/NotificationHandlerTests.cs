using Bogus;
using FollowerMicroService.API.Settings.NotificationSettings;

namespace FollowerMicroServiceUnitTests.SettingsTests;
public sealed class NotificationHandlerTests
{
    private readonly NotificationHandler _notificationHandler;
    private readonly Randomizer _random;

    public NotificationHandlerTests()
    {
        _notificationHandler = new NotificationHandler();
        _random = new Faker().Random;
    }

    [Fact]
    public void GetNotifications_AddNotifications_ListHasNotifications()
    {
        // A
        const int notificationCount = 2;
        AddNotificationsInRange(notificationCount);

        // A
        var notificationListResult = _notificationHandler.GetNotifications();

        // A
        Assert.Equal(notificationCount, notificationListResult.Count);
    }

    [Fact]
    public void HasNotifications_AddNotification_HasNotificationTrue()
    {
        // A
        var notificationToAdd = new Notification()
        {
            Key = _random.Word(),
            Message = _random.Word(),
        };

        _notificationHandler.AddNotification(notificationToAdd);

        // A
        var hasNotificationsResult = _notificationHandler.HasNotifications();

        // A
        Assert.True(hasNotificationsResult);
    }

    [Fact]
    public void HasNotifications_HasNotificationFalse()
    {
        var hasNotificationsResult = _notificationHandler.HasNotifications();

        Assert.False(hasNotificationsResult);
    }

    private void AddNotificationsInRange(int range)
    {
        for (var i = 0; i < range; i++)
        {
            var notification = new Notification()
            {
                Key = _random.Word(),
                Message = _random.Word()
            };

            _notificationHandler.AddNotification(notification);
        }
    }
}
