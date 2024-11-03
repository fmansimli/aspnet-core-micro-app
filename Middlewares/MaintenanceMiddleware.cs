using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace AspNet_micro_app.Middlewares;

public class MaintenanceMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Path.StartsWithSegments("/api/tasks"))
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = MediaTypeNames.Application.Json;

            var data = JsonSerializer.Serialize(
                new
                {
                    message = $"{context.Request.Path} the resource is in maintenance"
                }
            );

            await context.Response.WriteAsync(data);
            return;
        }

        await next(context);
    }
}