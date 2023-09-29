using _13_MVC_ETrade.Contexts;
using _13_MVC_ETrade.Models.Entities;
using _13_MVC_ETrade.Models.Entities.Enums;
using _13_MVC_ETrade.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace _13_MVC_ETrade.Repositories.Conctretes
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            product.DeleteDate= DateTime.Now;
            product.Status = Status.Passive;
            _context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetByProductId(int productId)
        {
            return _context.Products.Find(productId);
        }

        public void UpdateProduct(Product product)
        {
            product.UpdateDate = DateTime.Now;
            product.Status = Status.Modified;
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
