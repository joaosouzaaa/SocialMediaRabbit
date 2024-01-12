using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.API.Data.DatabaseContexts;
using NotificationMicroservice.API.Entities;
using NotificationMicroservice.API.Interfaces.Repositories;

namespace NotificationMicroservice.API.Data.Repositories;

public sealed class NotificationRepository : INotificationRepository
{
    private readonly NotificationDbContext _dbContext;
    private DbSet<Notification> DbContextSet => _dbContext.Set<Notification>();

    public NotificationRepository(NotificationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddAsync(Notification notification)
    {
        await DbContextSet.AddAsync(notification);

        return await _dbContext.SaveChangesAsync() > 0;
    }

    public Task<List<Notification>> GetAllByUserId(int userId) =>
        DbContextSet.AsNoTracking()
            .Where(n => n.UserId == userId)
            .ToListAsync();
}
