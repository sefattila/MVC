using _13_MVC_ETrade.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _13_MVC_ETrade.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
