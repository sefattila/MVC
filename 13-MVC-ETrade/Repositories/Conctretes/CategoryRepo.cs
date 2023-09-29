using _13_MVC_ETrade.Contexts;
using _13_MVC_ETrade.Models.Entities;
using _13_MVC_ETrade.Models.Entities.Enums;
using _13_MVC_ETrade.Repositories.Abstracts;

namespace _13_MVC_ETrade.Repositories.Conctretes
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;

        public CategoryRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            category.DeleteDate= DateTime.Now;
            category.Status = Status.Passive;
            _context.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetByCategoryId(int id)
        {
            return _context.Categories.Find(id);
        }

        public void UpdateCategory(Category category)
        {
            category.UpdateDate = DateTime.Now;
            category.Status = Status.Modified;
            //_context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
