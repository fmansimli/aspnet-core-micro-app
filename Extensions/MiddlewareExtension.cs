using AspNet_micro_app.Middlewares;

namespace AspNet_micro_app.Extensions;

public static class MiddlewareExtension
{
    public static void AddCustomMiddlewares(this IServiceCollection services)
    {
        services.AddTransient<ErrorMiddleware>();
        services.AddTransient<LoggingMiddleware>();
        services.AddTransient<MaintenanceMiddleware>();
    }
}