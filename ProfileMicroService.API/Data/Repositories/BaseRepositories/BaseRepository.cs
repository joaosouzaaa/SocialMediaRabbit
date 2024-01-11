using Microsoft.EntityFrameworkCore;
using ProfileMicroService.API.Data.DatabaseContexts;

namespace ProfileMicroService.API.Data.Repositories.BaseRepositories;

public abstract class BaseRepository<TEntity> : IDisposable
    where TEntity : class
{
    private readonly ProfileDbContext _dbContext;
    protected DbSet<TEntity> DbContextSet => _dbContext.Set<TEntity>();

    public BaseRepository(ProfileDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _dbContext.Dispose();
    }

    protected async Task<bool> SaveChangesAsync() =>
        await _dbContext.SaveChangesAsync() > 0;
}
