using _13_MVC_ETrade.Models.DTOs;
using _13_MVC_ETrade.Models.Entities;
using _13_MVC_ETrade.Models.Entities.Deneme;
using _13_MVC_ETrade.Models.VMs;
using _13_MVC_ETrade.Repositories.Abstracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _13_MVC_ETrade.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _repo;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

            //Deneme
            Employee employee = new Employee() { EmployeeId = 1, FirstName = "Sefa", LastName = "ATTİLA", Departmant = "MIT" };
            var empDTO = mapper.Map<Employee, EmployeeDTO>(employee);
            string id=empDTO.EmployeeId.ToString();
            string name = empDTO.FullName;
            string departmant = empDTO.Departmant;
        }

        public IActionResult Index()
        {
            //var cat1=_mapper.Map<CategoryListVM>(_repo.GetAllCategories());

            var cats = _repo.GetAllCategories().Select(c=>_mapper.Map<CategoryListVM>(c));
            return View(cats);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                var cat = _mapper.Map<Category>(categoryDTO);
                //Category category = new Category()
                //{
                //    Name = categoryDTO.CategoryName
                //};

                _repo.AddCategory(cat);
                return RedirectToAction("Index");
            }
            else
                return View(categoryDTO);
        }
    }
}
