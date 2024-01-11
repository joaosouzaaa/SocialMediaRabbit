namespace ProfileMicroService.API.Interfaces.Services;

public interface IProfileExistsServiceFacade
{
    Task<bool> ExistsAsync(int id);
}
