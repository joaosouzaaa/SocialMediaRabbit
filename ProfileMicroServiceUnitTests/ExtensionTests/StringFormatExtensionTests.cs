using ProfileMicroService.API.Extensions;

namespace ProfileMicroServiceUnitTests.ExtensionTests;
public sealed class StringFormatExtensionTests
{
    [Fact]
    public void FormatTo_FormatStringAccordingly()
    {
        // A
        var stringToFormat = "this is a string to format {0}";

        // A
        var stringFormatted = stringToFormat.FormatTo("test");

        // A
        Assert.Equal("this is a string to format test", stringFormatted);
    }
}
