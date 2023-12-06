using System.Threading;

public class BackgroundWorkerService : BackgroundService
{
    private readonly IConfiguration _configuration;
    readonly ILogger<BackgroundWorkerService> _logger;

    public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration; 
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var minute = int.Parse(_configuration["Time:minute"]);
            _logger.LogInformation("Worker running at : {time}", DateTimeOffset.Now);
            await Task.Delay(minute*1000, stoppingToken);
        }
    }
}