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
        private readonly IGetMovieService movieGetService;
        private readonly IMovieService _movieService;

        public MovieController(IGetMovieService movieGetServices, IMovieService movieService)
        {
            movieGetService = movieGetServices;
            _movieService = movieService;
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