using ProfileMicroService.API.DataTransferObjects.Profile;

namespace ProfileMicroService.API.Interfaces.Services;

public interface IProfileService
{
    Task<bool> AddAsync(ProfileSave profileSave);
}
