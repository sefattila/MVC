using _11_MVC_Entity.Classes;
using _11_MVC_Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace _11_MVC_Entity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppSettings _appSettings;

        public HomeController(ILogger<HomeController> logger,IOptions<AppSettings> appSettings)
        {
            //IOptions<> : Option sınıfı üzerinden erişim sağlamakve value özelliği ile döndürür
            
            //IOptionsSnapshot<T> : en son yapılandırma ayarlarını dinamik olarak ele almanıza olanak tanır.
            //Bir HTTP isteği sırasında güncel yapılandırma ayarlarına ihtiyacınız varsa.

            //IOptionsMonitor<T> : Options pattern üzerinde gerçekleşen değişiklikleri izlemek için kullanılır
            _appSettings= appSettings.Value;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Options()
        {
            string key = _appSettings.AppKey;
            int value = _appSettings.AppValue;

            return Content($"Options Key: {key} - Value: {value}");

            //Yapılandırma ayarlarının merkezi şekilde yapılmasını sağlıyor
            //Daha düzenli kod - kolayca yönetme - sürdürebilirlik - ortam bağımsızlığı 
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