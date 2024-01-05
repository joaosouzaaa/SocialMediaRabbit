using FluentValidation;
using FluentValidation.Results;
using Moq;
using ProfileMicroService.API.DataTransferObjects.Profile;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Interfaces.Mappers;
using ProfileMicroService.API.Interfaces.NotificationSettings;
using ProfileMicroService.API.Interfaces.Repositories;
using ProfileMicroService.API.Services;
using ProfileMicroService.API.Settings.NotificationSettings;
using ProfileMicroServiceUnitTests.TestBuilders;

namespace ProfileMicroServiceUnitTests.ServicesTests;
public sealed class ProfileMicroServiceTests
{
    private readonly Mock<IProfileRepository> _profileRepositoryMock;
    private readonly Mock<IProfileMapper> _profileMapperMock;
    private readonly Mock<IValidator<Profile>> _profileValidatorMock;
    private readonly Mock<INotificationHandler> _notificationHandlerMock;
    private readonly ProfileService _profileService;

    public ProfileMicroServiceTests()
    {
        _profileRepositoryMock = new Mock<IProfileRepository>();
        _profileMapperMock = new Mock<IProfileMapper>();
        _profileValidatorMock = new Mock<IValidator<Profile>>();
        _notificationHandlerMock = new Mock<INotificationHandler>();
        _profileService = new ProfileService(_profileRepositoryMock.Object, _profileMapperMock.Object, _profileValidatorMock.Object,
            _notificationHandlerMock.Object);
    }

    [Fact]
    public async Task AddAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var profileSave = ProfileBuilder.NewObject().SaveBuild();

        var profile = ProfileBuilder.NewObject().DomainBuild();
        _profileMapperMock.Setup(p => p.SaveToDomain(It.IsAny<ProfileSave>()))
            .Returns(profile);

        var validationResult = new ValidationResult();
        _profileValidatorMock.Setup(p => p.ValidateAsync(It.IsAny<Profile>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(validationResult);

        _profileRepositoryMock.Setup(p => p.AddAsync(It.IsAny<Profile>()))
            .ReturnsAsync(true);

        // A
        var addResult = await _profileService.AddAsync(profileSave);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<Notification>()), Times.Never());
        _profileRepositoryMock.Verify(p => p.AddAsync(It.IsAny<Profile>()), Times.Once());

        Assert.True(addResult);
    }

    [Fact]
    public async Task AddAsync_EntityInvalid_ReturnsFalse()
    {
        // A
        var profileSave = ProfileBuilder.NewObject().SaveBuild();

        var profile = ProfileBuilder.NewObject().DomainBuild();
        _profileMapperMock.Setup(p => p.SaveToDomain(It.IsAny<ProfileSave>()))
            .Returns(profile);

        var validationFailureList = new List<ValidationFailure>()
        {
            new ValidationFailure("test", "error"),
            new ValidationFailure("test", "error"),
            new ValidationFailure("test", "error"),
            new ValidationFailure("test", "error"),
            new ValidationFailure("test", "error")
        };
        var validationResult = new ValidationResult()
        {
            Errors = validationFailureList
        };
        _profileValidatorMock.Setup(p => p.ValidateAsync(It.IsAny<Profile>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(validationResult);

        // A
        var addResult = await _profileService.AddAsync(profileSave);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<Notification>()), Times.Exactly(validationResult.Errors.Count));
        _profileRepositoryMock.Verify(p => p.AddAsync(It.IsAny<Profile>()), Times.Never());

        Assert.False(addResult);
    }
}
