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

    //public async Task StartAsync(CancellationToken cancellationToken)
    //{
    //    _logger.LogInformation("Service started.");
       
    //}

    //public Task StopAsync(CancellationToken cancellationToken)
    //{
    //    _logger.LogInformation("Service stopped.");
    //    return Task.CompletedTask;
    //}

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