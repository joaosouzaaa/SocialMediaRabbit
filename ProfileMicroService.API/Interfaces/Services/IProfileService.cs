using ProfileMicroService.API.DataTransferObjects.Profile;
using ProfileMicroService.API.Settings.PaginationSettings;

namespace ProfileMicroService.API.Interfaces.Services;

public interface IProfileService
{
    Task<bool> AddAsync(ProfileSave profileSave);
    Task<PageList<ProfileResponse>> GetAllPaginatedAsync(PageParameters pageParameters);
}
