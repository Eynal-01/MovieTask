using MovieTask.Controllers;
using MovieTask.Services;
using MovieTask.Services.Abstract;
using System.Threading;

//public class BackgroundWorkerService : BackgroundService
//{
//    private readonly IConfiguration _configuration;
//    readonly ILogger<BackgroundWorkerService> _logger;
//    public static MovieController _controller;

//    public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger, IConfiguration configuration, MovieController controller)
//    {
//        _logger = logger;
//        _configuration = configuration;
//        _controller = controller;
//    }
//    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
//    {
//        while (!stoppingToken.IsCancellationRequested)
//        {
//            var minute = int.Parse(_configuration["Time:minute"]);
//            _logger.LogInformation("Worker running at : {time}", DateTimeOffset.Now);
//            await _controller.GetAsync();
//            await Task.Delay(minute * 1000, stoppingToken);
//        }
//    }
//}



public class BackgroundWorkerService : BackgroundService
{
    private readonly GetMovieService _movieGetService;
    private readonly IMovieService _movieService;
    private readonly ILogger<BackgroundWorkerService> _logger;

    public BackgroundWorkerService(
        GetMovieService movieGetService,
        IMovieService movieService,
        ILogger<BackgroundWorkerService> logger)
    {
        _movieGetService = movieGetService;
        _movieService = movieService;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await GetAndProcessMovieAsync();

            // Wait for 10 seconds
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }

    private async Task GetAndProcessMovieAsync()
    {
        var result = await _movieGetService.GetMovieFromApi();
        var movie = _movieService.GetAll().FirstOrDefault(m => m.Title == result.Title);

        if (movie == null)
        {
            _movieService.Add(result);
            _logger.LogInformation("New movie added: {Title}", result.Title);
        }
        else
        {
            _logger.LogInformation("Movie already exists: {Title}", result.Title);
        }
    }
}

