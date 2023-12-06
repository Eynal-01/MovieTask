using Microsoft.EntityFrameworkCore;
using MovieTask.Entities;

namespace MovieTask.Data
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }        
    }
}
