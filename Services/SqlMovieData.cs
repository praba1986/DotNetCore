using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfirstdotnetcore.Data;
using myfirstdotnetcore.Models;

namespace myfirstdotnetcore.Services
{
    public class SqlMovieData : IMovie
    {
        private MovieDbContext _context;

        public SqlMovieData(MovieDbContext context)
        {
            _context = context;
        }
        public Movie Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.OrderBy(r => r.Name);
        }
        public Movie Get(int id)
        {
            return _context.Movies.FirstOrDefault(r => r.Id == id);
        }
    }
}
