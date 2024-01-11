using ProfileMicroService.API.DataTransferObjects.Follow;
using ProfileMicroService.API.Settings.PaginationSettings;

namespace ProfileMicroService.API.Interfaces.Services;

public interface IFollowService
{
    Task<bool> AddAsync(FollowSave followSave);
    Task<PageList<FollowResponse>> GetAllFollowsByFollowingIdPaginatedAsync(GetAllFollowersRequest getAllFollowersRequest);
    Task<bool> DeleteAsync(int id);
}
