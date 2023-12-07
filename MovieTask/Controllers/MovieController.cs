using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTask.Services;
using MovieTask.Services.Abstract;
using MovieTask.Services.Concrete;

namespace MovieTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly GetMovieService movieGetService;
        private readonly IMovieService _movieService;
        //private readonly BackgroundWorkerService backgroundWorkerService;

        public MovieController(GetMovieService movieGetServices, IMovieService movieService/*, BackgroundWorkerService backgroundWorkerService*/)
        {
            movieGetService = movieGetServices;
            _movieService = movieService;
            //this.backgroundWorkerService = backgroundWorkerService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await movieGetService.GetMovieFromApi();
            var movie = _movieService.GetAll().FirstOrDefault(m => m.Title == result.Title);
            if (movie == null)
            {
                _movieService.Add(result);
            }
            return Ok();
        }
    }
}
