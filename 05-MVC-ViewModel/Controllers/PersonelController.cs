using _05_MVC_ViewModel.Models;
using _05_MVC_ViewModel.Models.Enums;
using _05_MVC_ViewModel.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace _05_MVC_ViewModel.Controllers
{
    public class PersonelController : Controller
    {
        List<Department> departments = new List<Department>()
        {
            new Department(){Id= 1,Name="Yazılım"},
            new Department(){Id= 2,Name="Muhasebe"},
            new Department(){Id= 3,Name="IT"},
            new Department(){Id= 4,Name="IK"}
        };

        List<Personel> personels = new List<Personel>()
        {
            new Personel(){Id= 1,Name="Sefa Attila",BithDate=new DateTime(1998,06,04),WorkingType=WorkingType.FullTime},
             new Personel(){Id= 2,Name="Emrah Yaşar",BithDate=new DateTime(2000,01,14),WorkingType=WorkingType.PartTime},
              new Personel(){Id= 3,Name="Ali Gündüz",BithDate=new DateTime(1997,04,15),WorkingType=WorkingType.Freelance}
        };

        public IActionResult Index()
        {
            return View(personels);
        }

        public IActionResult Create()
        {
            CreateVM vm = new CreateVM();
            vm.Personel = new Personel();
            vm.Departments= departments;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CreateVM createVM)
        {
            personels.Add(createVM.Personel);
            return View("Index", personels);
        }
    }
}
