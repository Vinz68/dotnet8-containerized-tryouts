using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace WorkerServiceNet8.Services;

public class PrintTimeService : BackgroundService
{
    private readonly ILogger<PrintTimeService> _logger;

    public PrintTimeService(ILogger<PrintTimeService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("The current UTC time is: {CurrentUTCTime}", DateTimeOffset.UtcNow);
            }
        }

    }
}

