using ProfileMicroService.API.DataTransferObjects.Follow;
using ProfileMicroService.API.Interfaces.Services;
using ProfileMicroService.API.Settings.NotificationSettings;
using Microsoft.AspNetCore.Mvc;
using ProfileMicroService.API.Settings.PaginationSettings;

namespace ProfileMicroService.API.Controllers;
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

    [HttpGet("get-all-paginated")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PageList<FollowResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<PageList<FollowResponse>> GetAllFollowsByFollowingIdPaginatedAsync([FromQuery] GetAllFollowersRequest getAllFollowersRequest) =>
        _followService.GetAllFollowsByFollowingIdPaginatedAsync(getAllFollowersRequest);

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<bool> DeleteAsync([FromQuery] int id) =>
        _followService.DeleteAsync(id);
}
