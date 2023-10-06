using System.Net;
using DroneDelivery.API.Modules.Common;
using Serilog.Extensions.Logging;

namespace DroneDelivery.API;

/// <summary>
/// </summary>
public static class Program
{
    private static readonly LoggerProviderCollection Providers = new();

    /// <summary>
    /// </summary>
    /// <param name="args"></param>
    [Obsolete]
    public static void Main(string[] args)
    {
        try
        {
            var hostBuilder = CreateHostBuilder(args).Build();
            Log.Information("Starting up");
            hostBuilder.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application start-up failed");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }


    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, configApp) =>
            {
                configApp.AddCommandLine(args);
                LoggingExtensions.CreateLog(Providers);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .UseSerilog(providers: Providers);
    }
}