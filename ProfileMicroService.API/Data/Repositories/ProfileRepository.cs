using Microsoft.EntityFrameworkCore;
using ProfileMicroService.API.Data.DatabaseContexts;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Interfaces.Repositories;
using ProfileMicroService.API.Settings.PaginationSettings;

namespace ProfileMicroService.API.Data.Repositories;

public sealed class ProfileRepository : IProfileRepository, IDisposable
{
    private readonly ProfileDbContext _dbContext;
    private DbSet<Profile> DbContextSet => _dbContext.Set<Profile>();

    public ProfileRepository(ProfileDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddAsync(Profile profile)
    {
        await DbContextSet.AddAsync(profile);

        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<PageList<Profile>> GetAllPaginatedAsync(PageParameters pageParameters)
    {
        var profileList = await DbContextSet.Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize).Take(pageParameters.PageSize).AsNoTracking().ToListAsync();
        var count = await DbContextSet.CountAsync();

        return new PageList<Profile>(profileList, count, pageParameters);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _dbContext.Dispose();
    }
}
