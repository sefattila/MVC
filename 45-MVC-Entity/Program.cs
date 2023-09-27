using _45_MVC_Entity.Models.Context;
using _45_MVC_Entity.Repository;
using Microsoft.EntityFrameworkCore;

namespace _45_MVC_Entity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<ICategoryRepo, CategoryRepo>();

            //connection adresimi göndermek için 
            builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer("Server=KDK-403-PC13-YZ;Database=CategoryDbMVC;Trusted_Connection=True;"));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}