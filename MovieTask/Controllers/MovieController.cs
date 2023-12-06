using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTask.Services.Abstract;
using MovieTask.Services.Concrete;

namespace MovieTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly GetMovieService getMovieService;

        public MovieController(GetMovieService getMovieService)
        {
            this.getMovieService = getMovieService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            getMovieService.GetMovieFromApi();
            return Ok();
        }
    }
}
