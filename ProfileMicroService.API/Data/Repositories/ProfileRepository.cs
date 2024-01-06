using Microsoft.EntityFrameworkCore;
using ProfileMicroService.API.Data.DatabaseContexts;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Interfaces.Repositories;
using ProfileMicroService.API.Settings.PaginationSettings;

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

    public async Task<PageList<Profile>> GetAllPaginatedAsync(PageParameters pageParameters)
    {
        var profileList = await _dbContextSet.Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize).Take(pageParameters.PageSize).AsNoTracking().ToListAsync();
        var count = await _dbContextSet.CountAsync();

        return new PageList<Profile>(profileList, count, pageParameters);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _dbContext.Dispose();
    }

    private async Task<bool> SaveChangesAsync() =>
        await _dbContext.SaveChangesAsync() > 0;
}
