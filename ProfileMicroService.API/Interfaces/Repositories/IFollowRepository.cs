using ProfileMicroService.API.Arguments;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Settings.PaginationSettings;
using System.Linq.Expressions;

namespace ProfileMicroService.API.Interfaces.Repositories;

public interface IFollowRepository
{
    Task<bool> AddAsync(Follow follow);
    Task<bool> AnyAsync(Expression<Func<Follow, bool>> predicate);
    Task<PageList<Follow>> GetAllFollowsByFollowingIdPaginatedAsync(GetAllFollowersArgument getAllFollowers);
    Task<bool> DeleteAsync(int id);
}
