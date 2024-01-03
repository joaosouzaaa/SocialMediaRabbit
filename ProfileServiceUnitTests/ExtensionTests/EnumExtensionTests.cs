using ProfileService.API.Domain.Enums;
using ProfileService.API.Extensions;

namespace ProfileServiceUnitTests.ExtensionTests;
public sealed class EnumExtensionTests
{
    [Fact]
    public void Description_SuccessfulScenario()
    {
        // A
        var enumToGetDescription = EMessage.Required;

        // A
        var enumDescription = enumToGetDescription.Description();

        // A
        Assert.Equal("{0} needs to be filled.", enumDescription);
    }
}
