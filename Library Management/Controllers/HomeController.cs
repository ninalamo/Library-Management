using System.Diagnostics;
using Library_Management.Data;
using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LibraryDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, LibraryDbContext libraryDbContext)
        {
            _logger = logger;
            _dbContext = libraryDbContext;
        }

        public IActionResult Index()
        {
            var data = _dbContext.Books.ToList();
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
