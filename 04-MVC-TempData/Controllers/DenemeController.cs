using Microsoft.AspNetCore.Mvc;

namespace _04_MVC_TempData.Controllers
{
    public class DenemeController : Controller
    {
        public IActionResult Index()
        {
            //ViewBag.Deneme = "Deneme Yazı";
            //var denemeMesaj = ViewBag.Deneme;

            TempData["ErrorMessage"] = "Bir Hata Gerçekleşti";

            return RedirectToAction("Error");
        }

        //viewbag her yaptığımzı istekte sıfırlanır
        //tempdata oturum(session) boyunca çalıştığı için veriyi gösterebiliriz
        public IActionResult Error()
        {
            //var denemeMesaj = ViewBag.Deneme;

            //var errorMesaj = TempData["ErrorMessage"] as string;
            //TempData.Keep("ErrorMessage");

            var errorMesaj = TempData.Peek("ErrorMessage") as string;

            return Content(errorMesaj);
        }
    }
}
