using Microsoft.AspNetCore.Mvc;
using MovieMVCDemo.Models;
using System.Linq;
using System.Collections.Generic;

namespace MovieMVCDemo.Controllers
{
    public class MovieController : Controller
    {
        // Fake database (in-memory list)
        private static List<Movie> movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "Inception", Year = 2010 },
            new Movie { Id = 2, Title = "Interstellar", Year = 2014 }
        };

        public IActionResult Index()
        {
            ViewData["Title"] = "All Movies";

            // HERE we SEND A LIST OF MOVIES (MODEL) to the View
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            // HERE we RECEIVE the id FROM THE ROUTE (asp-route-id)
            var movie = movies.FirstOrDefault(m => m.Id == id);

            // HERE we SEND A SINGLE MODEL to the View
            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            // HERE the View SENDS BACK a Movie MODEL to the Controller
            movie.Id = movies.Max(m => m.Id) + 1;
            movies.Add(movie);

            return RedirectToAction("Index");
        }
    }
}
