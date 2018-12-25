using myfirstdotnetcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstdotnetcore.Services
{
    public interface IMovie
    {
        IEnumerable<Movie> GetMovies();
        Movie Add(Movie movie);
        Movie Get(int id);
    }
}
