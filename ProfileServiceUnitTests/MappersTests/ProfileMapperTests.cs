using ProfileService.API.Mappers;
using ProfileServiceUnitTests.TestBuilders;

namespace ProfileServiceUnitTests.MappersTests;
public sealed class ProfileMapperTests
{
    private readonly ProfileMapper _profileMapper;

    public ProfileMapperTests()
    {
        _profileMapper = new ProfileMapper();
    }

    [Fact]
    public void SaveToDomain_SuccessfulScenario()
    {
        // A
        var profileSave = ProfileBuilder.NewObject().SaveBuild();

        // A
        var profileResult = _profileMapper.SaveToDomain(profileSave);

        // A
        Assert.Equal(profileResult.Username, profileSave.Username);
        Assert.Equal(profileResult.Email, profileSave.Email);
    }
}
