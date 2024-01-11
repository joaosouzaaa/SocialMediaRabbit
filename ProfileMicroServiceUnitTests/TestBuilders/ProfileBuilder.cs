using ProfileMicroService.API.DataTransferObjects.Profile;
using ProfileMicroService.API.Entities;

namespace ProfileMicroServiceUnitTests.TestBuilders;
public sealed class ProfileBuilder
{
    private static readonly Random _random = new();
    private string _username = "test";
    private string _email = "valid@email.com";
    private DateTime _creationDate = DateTime.Now;

    public static ProfileBuilder NewObject() =>
        new();

    public Profile DomainBuild() =>
        new()
        {
            CreationDate = _creationDate,
            Email = _email,
            Username = _username,
            Id = _random.Next()
        };

    public ProfileSave SaveBuild() =>
        new(_username,
            _email);

    public ProfileResponse ResponseBuild() =>
        new()
        {
            Id = _random.Next(),
            Username = _username,
            Email = _email,
            CreationDate = _creationDate
        };

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
