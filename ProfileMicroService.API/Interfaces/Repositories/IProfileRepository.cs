using ProfileMicroService.API.Entities;

namespace ProfileMicroService.API.Interfaces.Repositories;

public interface IProfileRepository : IDisposable
{
    Task<bool> AddAsync(Profile profile);
}
