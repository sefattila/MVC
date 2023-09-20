using _02_MVC_Controller.Models;
using Microsoft.AspNetCore.Mvc;

namespace _02_MVC_Controller.Controllers
{
    public class MainController : Controller
    {
        //Kullanıcı isteklerini alır, işler gerekirse modelle etkileşime girer ve sonuc olarak view oluşturur.
        /*
         * 1-Kullanıcı isteklerini karşılayabilirim
         * 2-İş Mantığı işlemi
         * 3-Model ile etkileşim
         * 4-View  ile etkileşim
         * 5-Üretim
         */

        //Metot Action,HTTP isteklerini işlemek için kullanılan metotlardır. HTTP GET ve POST isteklerini karşılar.
        //Paremetre alabililrler
        //ActionResult döndürür

        //HTTP isteklerini karşılamak için Action Verb dediğimiz yapıları kullanırız.
        /*
         * Get,Post,Put,Delete,Patch,Head,Options
         */

        //Action Result 

        [HttpGet]
        public IActionResult Index()
        {
            //return View("../Home/Index"); //sayfa çağırma
            //return PartialView();
            //return Content("Ana Sayfaya Hoş Geldiniz"); //String ifade göndermek için kullanılır
            //return Redirect("/otherPage"); //sayfa yönlendirme
            //return RedirectPermanent("../Home/Index"); //geçici sayfa yönlendirme

            //var data=new { Name="Sefa",Age=25};
            //return Json(data);

            //byte[] fileContent = GetFileContetnts();
            //return File(fileContent, "application/pdf", "deneme.pdf");

            //if (true)
            //{
            //    return View();
            //}
            //else
            //{
            //    return NotFound();
            //}

            var data=new { Message="Başarılı" };
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Index(Product product)
        {
            return Content("Ana Sayfaya Hoş Geldiniz");
        }

        //[HttpGet]
        //[HttpPost]
        //public IActionResult Index2(Product product)
        //{
        //    return Content("Ana Sayfaya Hoş Geldiniz");
        //}
    }
}
