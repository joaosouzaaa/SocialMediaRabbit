using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.API.Data.DatabaseContexts;

namespace NotificationMicroService.API.Settings.MigrationSettings;

public static class MigrationHandler
{
    public static void MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<NotificationDbContext>();

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
