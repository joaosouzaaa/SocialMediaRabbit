using FollowerMicroService.API.Data.DatabaseContexts;
using FollowerMicroService.API.Entities;
using FollowerMicroService.API.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FollowerMicroService.API.Data.Repositories;

public sealed class FollowRepository : IFollowRepository, IDisposable
{
    private readonly FollowerDbContext _dbContext;
    private DbSet<Follow> DbContextSet => _dbContext.Set<Follow>();

    public FollowRepository(FollowerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddAsync(Follow follow)
    {
        await DbContextSet.AddAsync(follow);

        return await _dbContext.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _dbContext.Dispose();
    }
}
