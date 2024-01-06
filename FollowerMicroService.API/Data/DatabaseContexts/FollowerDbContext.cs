using Microsoft.EntityFrameworkCore;

namespace FollowerMicroService.API.Data.DatabaseContexts;

public sealed class FollowerDbContext : DbContext
{
    public FollowerDbContext(DbContextOptions<FollowerDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FollowerDbContext).Assembly);
    }
}
