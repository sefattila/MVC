using _13_MVC_ETrade.Models.Entities;

namespace _13_MVC_ETrade.Repositories.Abstracts
{
    public interface ICategoryRepo
    {
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);
        Category GetByCategoryId(int id);
        List<Category> GetAllCategories();
    }
}
