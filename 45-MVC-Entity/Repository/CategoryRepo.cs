using _45_MVC_Entity.Models;
using _45_MVC_Entity.Models.Context;

namespace _45_MVC_Entity.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;

        public CategoryRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CategoryAdd(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void CategoryDelete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public Category CategoryGetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void CategoryUpdate(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public List<Category> GetAllCategory()
        {
            return _context.Categories.ToList();
        }
    }
}
