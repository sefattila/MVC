using _03_MVC_Views.Models;
using Microsoft.AspNetCore.Mvc;

namespace _03_MVC_Views.Controllers
{
    public class ProductController : Controller
    {
        IList<Product> products = new List<Product>()
        {
            new Product(){Id=1,Title="Kalem-1",Price=50},
            new Product(){Id=2,Title="Kalem-2",Price=65},
            new Product(){Id=3,Title="Kalem-3",Price=70},
            new Product(){Id=4,Title="Kalem-4",Price=30},
            new Product(){Id=5,Title="Kalem-5",Price=40},
            new Product(){Id=6,Title="Kalem-6",Price=80},
        };
        public IActionResult Index()
        {
            ViewBag.Subject = "Productlerı View Bag ile getir";
            ViewBag.Products = products;
            ViewData["Subject2"] = "Ürünleri View Data ile getir";
            ViewData["Products2"] = products;

            ViewBag.Deneme = "Deneme";
            return View(products);
        }

        public IActionResult Detail(int id)
        {
            //return Content(id.ToString());
            var product = products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }
    }
}
