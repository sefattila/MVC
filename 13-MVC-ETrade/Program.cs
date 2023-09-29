using _13_MVC_ETrade.AutoMapper;
using _13_MVC_ETrade.Contexts;
using _13_MVC_ETrade.Repositories.Abstracts;
using _13_MVC_ETrade.Repositories.Conctretes;
using Microsoft.EntityFrameworkCore;

namespace _13_MVC_ETrade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddAutoMapper(typeof(Mapping));
            var conn = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conn));

            builder.Services.AddTransient<ICategoryRepo, CategoryRepo>();
            builder.Services.AddTransient<IProductRepo, ProductRepo>();

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