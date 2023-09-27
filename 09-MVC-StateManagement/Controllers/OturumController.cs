using Microsoft.AspNetCore.Mvc;

namespace _09_MVC_StateManagement.Controllers
{
    public class OturumController : Controller
    {
        const string personelAdi = "ad";
        const string personelMail = "mail";
        const string personelYasi = "yas";
        const string personelRolu = "rol";
        public IActionResult Index()
        {
            HttpContext.Session.SetString("ad", "Bilge Adam");
            HttpContext.Session.SetInt32(personelYasi, 18);
            HttpContext.Session.SetString(personelMail, "bilge@adam.com");
            HttpContext.Session.SetString(personelRolu, "Yazılım");

            return View();
        }

        public IActionResult Oturum()
        {
            ViewBag.prsAd = HttpContext.Session.GetString("ad");
            ViewBag.prsMail = HttpContext.Session.GetString(personelMail);
            ViewBag.prsYas = HttpContext.Session.GetInt32(personelYasi);
            ViewBag.prsRol = HttpContext.Session.GetString(personelRolu);

            return View();
        }
    }
}
