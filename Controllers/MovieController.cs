using Microsoft.AspNetCore.Mvc;
using myfirstdotnetcore.Models;
using myfirstdotnetcore.Services;
using System.Linq;

namespace myfirstdotnetcore.Controllers
{
    [Route("[controller]/[action]")]
    public class MovieController : Controller
    {
        public MovieController(IMovie movie)
        {
            _movies = movie;
        }

        private IMovie _movies;
        public IActionResult Index()
        {
            var model = _movies.GetMovies().OrderBy(r=>r.Id);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if(ModelState.IsValid)
            {
                var newMovie = new Movie();
                newMovie.Name = movie.Name;
                _movies.Add(newMovie);
                return RedirectToAction(nameof(Details), new { id = newMovie.Id });
            }
            else
            {
                return View();
            }
        }
        public IActionResult Details(int id)
        {
            var model = _movies.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public string About()
        {
            return "Hi from Movie controller!";
        }
    }
}
