using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfirstdotnetcore.Models;

namespace myfirstdotnetcore.Services
{
    public class InMemoryMovie : IMovie
    {
        public InMemoryMovie()
        {
            _movies = new List<Movie>
            {
                new Movie {Id=1,Name="Spiderman" },
                new Movie{Id=2,Name="Lion"}
            };
        }
        public IEnumerable<Movie> GetMovies()
        {
            return _movies.OrderBy(r => r.Id);
        }

        public Movie Add(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Movie Get(int id)
        {
            throw new NotImplementedException();
        }

        List<Movie> _movies;
    }
}
