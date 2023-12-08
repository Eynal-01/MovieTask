using MovieTask.Entities;

namespace MovieTask.Services.Abstract
{
    public interface IGetMovieService
    {
        Task<Movie> GetMovieFromApi();
    }
}