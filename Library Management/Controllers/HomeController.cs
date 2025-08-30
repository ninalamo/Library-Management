using System.Diagnostics;
using Library_Management.Data;
using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookDbContext _bookdbContext;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, BookDbContext context)
        {
            _logger = logger;
            _bookdbContext = context;
        }

        public IActionResult Index()
        {
            var data = _bookdbContext.Books.ToList();
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
