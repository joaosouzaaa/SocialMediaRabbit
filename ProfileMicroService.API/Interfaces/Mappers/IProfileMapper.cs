using ProfileMicroService.API.DataTransferObjects.Profile;
using ProfileMicroService.API.Entities;

namespace ProfileMicroService.API.Interfaces.Mappers;

public interface IProfileMapper
{
    Profile SaveToDomain(ProfileSave profileSave);
}
