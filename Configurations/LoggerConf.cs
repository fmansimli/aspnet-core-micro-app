using Elastic.CommonSchema.Serilog;
using Serilog;

namespace AspNet_micro_app.Configurations;

public static class LoggingConf
{
    public static void UseSerilogConf(this IHostBuilder host, IConfiguration config)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel
            .Information()
            .Enrich
            .WithMachineName()
            .WriteTo
            .Console(new EcsTextFormatter(
                new()
                {
                    IncludeHost = false,
                    IncludeUser = false,
                    IncludeProcess = false,
                    IncludeActivityData = false
                }))
            .ReadFrom
            .Configuration(config)
            .CreateLogger();

        host.UseSerilog();
    }
}