using FollowerMicroService.API.DataTransferObjects.Follow;

namespace FollowerMicroService.API.Interfaces.Services;

public interface IFollowService
{
    Task<bool> AddAsync(FollowSave followSave);
}
