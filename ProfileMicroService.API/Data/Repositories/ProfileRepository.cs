using Microsoft.EntityFrameworkCore;
using ProfileMicroService.API.Data.DatabaseContexts;
using ProfileMicroService.API.Data.Repositories.BaseRepositories;
using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Interfaces.Repositories;
using ProfileMicroService.API.Settings.PaginationSettings;

namespace ProfileMicroService.API.Data.Repositories;

public sealed class ProfileRepository : BaseRepository<Profile>, IProfileRepository
{
    public ProfileRepository(ProfileDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> AddAsync(Profile profile)
    {
        await DbContextSet.AddAsync(profile);

        return await SaveChangesAsync();
    }

    public async Task<PageList<Profile>> GetAllPaginatedAsync(PageParameters pageParameters)
    {
        var profileList = await DbContextSet.Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize).Take(pageParameters.PageSize).AsNoTracking().ToListAsync();
        var count = await DbContextSet.CountAsync();

        return new PageList<Profile>(profileList, count, pageParameters);
    }

    public Task<bool> ExistsAsync(int id) =>
        DbContextSet.AsNoTracking().AnyAsync(p => p.Id == id);
}
