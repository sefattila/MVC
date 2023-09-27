using Microsoft.AspNetCore.Mvc;

namespace _09_MVC_StateManagement.Controllers
{
    public class KurabiyeController : Controller
    {
        public string KurabiyeGetir(string kurabiye)
        {
            HttpContext.Request.Cookies.TryGetValue(kurabiye, out var cookies);
            return cookies;
        }
        public IActionResult Index()
        {
            HttpContext.Response.Cookies.Append("Ad", "Bilge Adam");
            HttpContext.Response.Cookies.Append("Yas", "10");
            return View();
        }

        public IActionResult Cerez()
        {
            string ad= KurabiyeGetir("Ad");
            string yas = KurabiyeGetir("Yas");

            return Content("Adı: " + ad + "Yasi: " + yas);
        }
    }
}
