using MovieTask.Entities;
using MovieTask.Repositories.Abstract;
using MovieTask.Services.Abstract;
using System.Linq.Expressions;

namespace MovieTask.Services.Concrete
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void Add(Movie entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Movie Get(Expression<Func<Movie, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}
