namespace NotificationMicroservice.API.Middlewares;

public sealed class UnexpectedErrorMiddleware
{
    private readonly RequestDelegate _next;

    public UnexpectedErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var response = """
            {
              "key": "Unexpected error",
              "message": "An unexpected error happened."
            }
            """;

            await context.Response.WriteAsync(response);
        }
    }
}
