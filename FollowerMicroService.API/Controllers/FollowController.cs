using FollowerMicroService.API.DataTransferObjects.Follow;
using FollowerMicroService.API.Interfaces.Services;
using FollowerMicroService.API.Settings.NotificationSettings;
using Microsoft.AspNetCore.Mvc;

namespace FollowerMicroService.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class FollowController : ControllerBase
{
    private readonly IFollowService _followService;

    public FollowController(IFollowService followService)
    {
        _followService = followService;
    }

    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> AddAsync([FromBody] FollowSave followSave) =>
        _followService.AddAsync(followSave);
}
