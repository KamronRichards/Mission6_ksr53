using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6_ksr53.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_ksr53.Controllers
{
    public class HomeController : Controller
    {
        private AddMovieContext daContext { get; set; }

        public HomeController(AddMovieContext someName)
        {
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categorys = daContext.Categorys.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(MovieResponse ar)
        {
            if (ModelState.IsValid)
            {
                daContext.Update(ar);
                daContext.SaveChanges();

                return RedirectToAction("Collection");
            }
            else
            {
                ViewBag.Categorys = daContext.Categorys.ToList();
                return View(ar);
            }
        }

        [HttpGet]
        public IActionResult Collection()
        {
            var movies = daContext.responses.Include(x => x.Category).OrderBy(x => x.Title).ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categorys = daContext.Categorys.ToList();

            var movie = daContext.responses.Single(x => x.MovieID == movieid);

            return View("MovieForm", movie);
        }
        [HttpPost]
        public IActionResult Edit(MovieResponse blah)
        {
            daContext.Update(blah);
            daContext.SaveChanges();

            return RedirectToAction("Collection");
        }
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = daContext.responses.Single(x => x.MovieID == movieid);


            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(MovieResponse ar)
        {
            daContext.responses.Remove(ar);
            daContext.SaveChanges();
            return RedirectToAction("Collection");
        }

        public IActionResult Podcast()
        {
            return View();
        }

        public IActionResult Confirmation()
        {
            return View();
        }

    }
}
