using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTask.Services.Abstract;

namespace MovieTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
    }
}
