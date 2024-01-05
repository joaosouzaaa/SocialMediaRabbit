using ProfileMicroService.API.Enums;
using ProfileMicroService.API.Extensions;

namespace ProfileMicroServiceUnitTests.ExtensionTests;
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
