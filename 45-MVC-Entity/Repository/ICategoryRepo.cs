using _45_MVC_Entity.Models;

namespace _45_MVC_Entity.Repository
{
    public interface ICategoryRepo
    {
        void CategoryAdd(Category category);
        void CategoryUpdate(Category category);
        void CategoryDelete(Category category); 
        Category CategoryGetById(int id);
        List<Category> GetAllCategory();
    }
}
