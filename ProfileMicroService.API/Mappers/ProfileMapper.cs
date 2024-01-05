using ProfileMicroService.API.DataTransferObjects.Profile;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Interfaces.Mappers;

namespace ProfileMicroService.API.Mappers;

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
