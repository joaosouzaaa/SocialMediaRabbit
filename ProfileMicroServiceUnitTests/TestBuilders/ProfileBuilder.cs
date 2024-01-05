using ProfileMicroService.API.DataTransferObjects.Profile;
using ProfileMicroService.API.Entities;

namespace ProfileMicroServiceUnitTests.TestBuilders;
public sealed class ProfileBuilder
{
    private string _username = "test";
    private string _email = "valid@email.com";

    public static ProfileBuilder NewObject() =>
        new();

    public Profile DomainBuild() =>
        new()
        {
            CreationDate = DateTime.UtcNow,
            Email = _email,
            Username = _username,
            Id = 12
        };

    public ProfileSave SaveBuild() =>
        new(_username, _email);

    public ProfileBuilder WithUsername(string username)
    {
        _username = username;

        return this;
    }

    public ProfileBuilder WithEmail(string email)
    {
        _email = email;

        return this;
    }
}
