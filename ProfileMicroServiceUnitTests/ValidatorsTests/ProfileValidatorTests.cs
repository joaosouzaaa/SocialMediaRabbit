using ProfileMicroService.API.Settings.ValidatorsSettings;
using ProfileMicroServiceUnitTests.TestBuilders;

namespace ProfileMicroServiceUnitTests.ValidatorsTests;
public sealed class ProfileValidatorTests
{
    private readonly ProfileValidator _profileValidator;

    public ProfileValidatorTests()
    {
        _profileValidator = new ProfileValidator();
    }

    [Fact]
    public async Task ValidateAsync_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var profile = ProfileBuilder.NewObject().DomainBuild();

        // A
        var validationResult = await _profileValidator.ValidateAsync(profile);

        // A
        Assert.True(validationResult.IsValid);
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("invalid@")]
    [InlineData("inval@id@.")]
    [InlineData("invali@@d")]
    public async Task ValidateAsync_InvalidEmail_ReturnsFalse(string email)
    {
        // A
        var profileWithInvalidEmail = ProfileBuilder.NewObject().WithEmail(email).DomainBuild();

        // A
        var validationResult = await _profileValidator.ValidateAsync(profileWithInvalidEmail);

        // A
        Assert.False(validationResult.IsValid);
    }

    [Theory]
    [MemberData(nameof(InvalidUsernameParameters))]
    public async Task ValidateAsync_InvalidUsername_ReturnsFalse(string username)
    {
        // A
        var profileWithInvalidUsername = ProfileBuilder.NewObject().WithUsername(username).DomainBuild();

        // A
        var validationResult = await _profileValidator.ValidateAsync(profileWithInvalidUsername);

        // A
        Assert.False(validationResult.IsValid);
    }

    public static IEnumerable<object[]> InvalidUsernameParameters()
    {
        yield return new object[]
        {
            new string('a', 51)
        };

        yield return new object[]
        {
            "a"
        };

        yield return new object[]
        {
            ""
        };
    }
}
