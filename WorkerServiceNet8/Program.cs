using Serilog;
using WorkerServiceNet8.Services;

namespace WorkerServiceNet8;

public class Program
{
    public static int Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
           .WriteTo.Console()
           .CreateLogger();

        try
        {
            Log.Information("<{ThreadId}> {ApplicationName} is starting...", Environment.CurrentManagedThreadId, AppDomain.CurrentDomain.FriendlyName);

            var hostBuilder = CreateHostBuilder(args);
            var host = hostBuilder.Build();

            host.Run();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        IHostBuilder hostBuilder = new HostBuilder();

        // Setup Configuration (Settings)
        hostBuilder.ConfigureAppConfiguration(config =>
        {
            config.SetBasePath(Directory.GetCurrentDirectory());
            config.AddJsonFile("appsettings.json");
        });

        // Setup DI
        hostBuilder.ConfigureServices(services =>
        {
            services.AddHostedService<PrintTimeService>();
        });


        // Setup Logging
        hostBuilder.UseSerilog((context, services, loggerConfiguration) => loggerConfiguration
            .ReadFrom.Configuration(context.Configuration)
            //.ReadFrom.Services(services)
            //.Enrich.WithThreadId()
            //.Enrich.FromLogContext()
            //.WriteTo.Console()
             );

        return hostBuilder;
    }


}