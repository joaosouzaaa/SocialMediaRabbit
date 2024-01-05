using Microsoft.EntityFrameworkCore;
using ProfileMicroService.API.Data.DatabaseContexts;

namespace ProfileMicroService.API.Settings.MigrationSettings;

public static class MigrationHandler
{
    public static void MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<ProfileDbContext>();

        try
        {
            dbContext.Database.Migrate();
        }
        catch
        {
            throw;
        }
    }
}
