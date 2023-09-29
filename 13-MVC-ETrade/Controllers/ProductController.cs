using _13_MVC_ETrade.Models.Entities;
using _13_MVC_ETrade.Models.VMs;
using _13_MVC_ETrade.Repositories.Abstracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _13_MVC_ETrade.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _repo;
        private readonly IMapper _mapper;
        private readonly ICategoryRepo _catRepo;

        public ProductController(IProductRepo repo, IMapper mapper, ICategoryRepo catRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _catRepo = catRepo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAllProducts());
        }
        public IActionResult Create()
        {
            ProductCreateVM createVM = new ProductCreateVM();
            createVM.Categories = _catRepo.GetAllCategories();
            return View(createVM);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateVM createVM)
        {
            var product = _mapper.Map<Product>(createVM);
            _repo.AddProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_repo.GetByProductId(id));
        }
        [HttpPost]
        public IActionResult Edit(Product product, IFormFile file)
        {
            string imgName = "";
            if (file != null)
            {
                string imgExtension=Path.GetExtension(file.FileName);
                imgName = Guid.NewGuid() + imgExtension;

                string path=Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/{imgName}");

                using var stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);
            }
            product.ProductImage = imgName;
            _repo.UpdateProduct(product);
            return RedirectToAction("Index");
        }
    }
}
