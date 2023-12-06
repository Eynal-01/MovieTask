using MovieTask.Controllers;
using System.Threading;

public class BackgroundWorkerService : BackgroundService
{
    private readonly IConfiguration _configuration;
    readonly ILogger<BackgroundWorkerService> _logger;
    public static MovieController _controller;

    public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger, IConfiguration configuration, MovieController controller)
    {
        _logger = logger;
        _configuration = configuration;
        _controller = controller;       
    }
    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var minute = int.Parse(_configuration["Time:minute"]);
            _logger.LogInformation("Worker running at : {time}", DateTimeOffset.Now);
            _controller.GetAsync().Wait();
            await Task.Delay(minute * 1000, stoppingToken);
        }
    }
}
