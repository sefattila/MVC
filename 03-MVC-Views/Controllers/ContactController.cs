using _03_MVC_Views.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace _03_MVC_Views.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View("GetMessage");
        }

        [HttpGet]
        public IActionResult GetMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetMessage(MessageSave message)
        {
            if(message != null)
            {
                ViewBag.Message = "Başarılı";
                return View(message);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult MesajGonder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MesajGonder(MessageSave message, string firstName)
        {
            return View();
        }
    }
}
