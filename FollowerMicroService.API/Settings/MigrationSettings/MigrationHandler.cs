using FollowerMicroService.API.Data.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace FollowerMicroService.API.Settings.MigrationSettings;

public static class MigrationHandler
{
    public static void MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<FollowerDbContext>();

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
