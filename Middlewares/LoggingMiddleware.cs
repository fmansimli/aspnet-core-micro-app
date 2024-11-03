namespace AspNet_micro_app.Middlewares;

public class LoggingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Console.WriteLine("URL::" + context.Request.Path);
        await next(context);
    }
}