using System.Net;
using System.Net.Mime;
using System.Text.Json;
using AspNet_micro_app.Exceptions;

namespace AspNet_micro_app.Middlewares;

public class ErrorMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (BaseException ex)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = ex.HttpCode;

            var resp = JsonSerializer.Serialize(ex.Serialize());
            await context.Response.WriteAsync(resp);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = MediaTypeNames.Application.Json;

            var resp = JsonSerializer
                .Serialize(new ServerException($"Unknown exception ({ex.Message})")
                    .Serialize());

            await context.Response.WriteAsync(resp);
        }
    }
}