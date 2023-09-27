using Microsoft.AspNetCore.Mvc;

namespace _08_MVC_Routing.Controllers
{
    [Route("products")]
    public class UrunController : Controller
    {
        [Route("product")]
        [Route("products")]
        [Route("products/index/{id?}")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            return Content($"Product Id:{id}");
        }

        [Route("Create/{entryId:int}/{slugs}")]
        public IActionResult Create(int entryId,string slugs)
        {
            return Content($"Create: Entry Id: {entryId} Slugs: {slugs}");
        }

        [Route("Create/{entryId:min(1):range(1,500)}/{slugs}")] //range(1,500)
        public IActionResult Create2(int entryId, string slugs)
        {
            return Content($"Create: Entry Id: {entryId} Slugs: {slugs}");
        }

        [Route("Create//{slug:regex()}")] 
        public IActionResult Create3(int entryId, string slugs)
        {
            return Content($"Create: Entry Id: {entryId} Slugs: {slugs}");
        }

        //products/urun/id?magaza=hepsi&konum=istanbul
        [Route("urun/{id}")]
        public IActionResult GetProduct(int id)
        {
            string gelenDeger1 = Request.Query["magaza"];
            string gelenDeger2 = Request.Query["konum"];

            return Content($"Urun ID: {id} Magaza: {gelenDeger1} Konum: {gelenDeger2}");
        }

        //{controller}{action}{area}{page}{id}{id}{slug}
    }
}
