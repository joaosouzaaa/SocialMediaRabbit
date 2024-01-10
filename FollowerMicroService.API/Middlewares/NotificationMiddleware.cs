using FollowerMicroService.API.Settings.NotificationSettings;
using System.Text.Json;

namespace FollowerMicroService.API.Middlewares;

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
            
            const string unexpectedErrorKey = "Unexpected Error";

            var response = new List<Notification>()
            {
                new()
                {
                    Message = exception.Message,
                    Key = unexpectedErrorKey
                }
            };

            var jsonResponse = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
