using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;

        private AddMovieContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, AddMovieContext someName)
        {
            _logger = logger;
            context = someName;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(MovieResponse ar)
        {
            context.Add(ar);
            context.SaveChanges();

            return View("Confirmation", ar);

        }

        public IActionResult Podcast()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
