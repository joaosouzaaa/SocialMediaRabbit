using Microsoft.EntityFrameworkCore;
using ProfileService.API.Entities;

namespace UserService.API.Data.DatabaseContexts;

public sealed class ProfileDbContext : DbContext
{
	public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
	{

	}

	public DbSet<Profile> Profiles { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProfileDbContext).Assembly);
	}
}
