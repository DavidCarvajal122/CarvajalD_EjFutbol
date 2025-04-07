using System.Diagnostics;
using CarvajalD_EjFutbol.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarvajalD_EjFutbol.Controllers
{
    public class HomeController : Controller
    {
        /*Comentario de verificaci�n de Git*/
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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
