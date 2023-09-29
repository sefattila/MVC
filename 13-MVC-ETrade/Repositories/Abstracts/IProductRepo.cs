using _13_MVC_ETrade.Models.Entities;

namespace _13_MVC_ETrade.Repositories.Abstracts
{
    public interface IProductRepo
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        Product GetByProductId(int productId);
        List<Product> GetAllProducts();
    }
}
