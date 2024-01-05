using Microsoft.EntityFrameworkCore;
using ProfileMicroService.API.Data.DatabaseContexts;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Interfaces.Repositories;

namespace ProfileMicroService.API.Data.Repositories;

public sealed class ProfileRepository : IProfileRepository
{
    private readonly ProfileDbContext _dbContext;
    private DbSet<Profile> _dbContextSet => _dbContext.Set<Profile>();

    public ProfileRepository(ProfileDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddAsync(Profile profile)
    {
        await _dbContextSet.AddAsync(profile);

        return await SaveChangesAsync();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _dbContext.Dispose();
    }

    private async Task<bool> SaveChangesAsync() =>
        await _dbContext.SaveChangesAsync() > 0;
}
