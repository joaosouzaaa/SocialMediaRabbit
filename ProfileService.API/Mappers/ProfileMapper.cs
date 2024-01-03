using ProfileService.API.DataTransferObjects.Profile;
using ProfileService.API.Domain.Entities;
using ProfileService.API.Interfaces.Mappers;

namespace ProfileService.API.Mappers;

public sealed class ProfileMapper : IProfileMapper
{
    public Profile SaveToDomain(ProfileSave profileSave) =>
        new()
        {
            CreationDate = DateTime.UtcNow,
            Email = profileSave.Email,
            Username = profileSave.Username
        };
}
