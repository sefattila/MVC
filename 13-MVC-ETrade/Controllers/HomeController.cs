using _13_MVC_ETrade.Models;
using _13_MVC_ETrade.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _13_MVC_ETrade.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepo _repo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAllProducts());
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