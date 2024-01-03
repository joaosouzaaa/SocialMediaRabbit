using ProfileService.API.DataTransferObjects.Profile;
using ProfileService.API.Domain.Entities;

namespace ProfileService.API.Interfaces.Mappers;

public interface IProfileMapper
{
    Profile SaveToDomain(ProfileSave profileSave);
}
