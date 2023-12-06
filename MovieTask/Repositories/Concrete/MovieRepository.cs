using MovieTask.Data;
using MovieTask.Entities;
using MovieTask.Repositories.Abstract;
using System.Linq.Expressions;

namespace MovieTask.Repositories.Concrete
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public void Add(Movie entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Movie entity)
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
