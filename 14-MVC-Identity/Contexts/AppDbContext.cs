using _14_MVC_Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace _14_MVC_Identity.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Book> Books { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
