using _01_MVC_FirstPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_MVC_FirstPage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // return Content("Merhaba MVC Dünyası - İlk MVC Kodum");

            Movie movie = new Movie() { Id = 1, Title = "The GodFather", ReleaseDate = new DateTime(1972, 2, 24) };

            return View(movie);
        }

        public IActionResult Create()
        {
            return Content("Oluşturuldu");
        }
    }
}
