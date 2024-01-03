using ProfileService.API.Domain.Entities;

namespace ProfileService.API.Interfaces.Repositories;

public interface IProfileRepository : IDisposable
{
    Task<bool> AddAsync(Profile profile);
    Task<bool> UpdateAsync(Profile profile);
}
