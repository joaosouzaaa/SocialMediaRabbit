using ProfileMicroService.API.Enums;
using ProfileMicroService.API.Settings.NotificationSettings;
using System.Text.Json;

namespace ProfileMicroService.API.Middlewares;

public sealed class NotificationMiddleware
{
    private readonly RequestDelegate _next;

    public NotificationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "application/json";

            var response = new List<Notification>()
            {
                new Notification()
                {
                    Message = exception.Message,
                    Key = nameof(EMessage.UnexpectedError)
                }
            };

            var jsonResponse = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
