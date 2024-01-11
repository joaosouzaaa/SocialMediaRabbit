using ProfileMicroService.API.Data.DatabaseContexts;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Interfaces.Repositories;
using ProfileMicroService.API.Data.Repositories.BaseRepositories;
using ProfileMicroService.API.Settings.PaginationSettings;
using Microsoft.EntityFrameworkCore;
using ProfileMicroService.API.Arguments;
using System.Linq.Expressions;

namespace ProfileMicroService.API.Data.Repositories;

public sealed class FollowRepository : BaseRepository<Follow>, IFollowRepository
{
    public FollowRepository(ProfileDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> AddAsync(Follow follow)
    {
        await DbContextSet.AddAsync(follow);

        return await SaveChangesAsync();
    }

    public Task<bool> AnyAsync(Expression<Func<Follow, bool>> predicate) =>
        DbContextSet.AsNoTracking().AnyAsync(predicate);

    public async Task<PageList<Follow>> GetAllFollowsByFollowingIdPaginatedAsync(GetAllFollowersArgument getAllFollowers)
    {
        var query = DbContextSet.Include(f => f.Follower).Where(f => f.FollowingId == getAllFollowers.FollowingId);

        var followList = await query.Skip((getAllFollowers.PageNumber - 1) * getAllFollowers.PageSize).Take(getAllFollowers.PageSize).AsNoTracking().ToListAsync();
        var count = await query.CountAsync();

        return new PageList<Follow>(followList, count, getAllFollowers);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var follow = await DbContextSet.FirstOrDefaultAsync(f => f.Id == id);

        DbContextSet.Remove(follow!);

        return await SaveChangesAsync();
    }
}
