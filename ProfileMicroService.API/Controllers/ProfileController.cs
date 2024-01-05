using Microsoft.AspNetCore.Mvc;
using ProfileMicroService.API.DataTransferObjects.Profile;
using ProfileMicroService.API.Interfaces.Services;
using ProfileMicroService.API.Settings.NotificationSettings;

namespace ProfileMicroService.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> AddAsync([FromBody] ProfileSave profileSave) =>
        _profileService.AddAsync(profileSave);
}
