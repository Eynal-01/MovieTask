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
           _context.Movies.Add(entity); 
            _context.SaveChanges();
        }

        public void Delete(Movie entity)
        {
            _context.Movies.Remove(entity);
            _context.SaveChanges();
        }

        public Movie Get(Expression<Func<Movie, bool>> expression)
        {
            var movie = _context.Movies.SingleOrDefault(expression);
            return movie;
        }

        public IEnumerable<Movie> GetAll()
        {
            var movies = _context.Movies;
            return movies;
        }

        public void Update(Movie entity)
        {
            _context.Movies.Update(entity);
            _context.SaveChanges();
        }
    }
}