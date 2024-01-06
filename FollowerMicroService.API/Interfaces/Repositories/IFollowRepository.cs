using FollowerMicroService.API.Entities;

namespace FollowerMicroService.API.Interfaces.Repositories;

public interface IFollowRepository
{
    Task<bool> AddAsync(Follow follow);
}
