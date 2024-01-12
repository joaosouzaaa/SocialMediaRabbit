using Microsoft.AspNetCore.Mvc;
using NotificationMicroservice.API.DataTransferObjects.Notification;
using NotificationMicroservice.API.Interfaces.Services;

namespace NotificationMicroservice.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet("get-all-by-user")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NotificationResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<List<NotificationResponse>> GetAllByUserIdAsync([FromQuery] int userId) =>
        _notificationService.GetAllByUserIdAsync(userId);
}
