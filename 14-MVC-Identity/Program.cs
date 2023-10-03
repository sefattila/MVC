using _14_MVC_Identity.Contexts;
using _14_MVC_Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace _14_MVC_Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var conn = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection String Bulunamadı");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(conn);
            });

            //Add Identity Service
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                //Password
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                //User
                options.User.RequireUniqueEmail= true; //aynı e posta ile birden fazla hesap oluşturma(benzersiz olacak dedik)
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+"; //izin verilen karakterler
                
                //SignIn
                options.SignIn.RequireConfirmedEmail= false; //Eposta onayı gereksin mi?
                options.SignIn.RequireConfirmedPhoneNumber= false;
                options.SignIn.RequireConfirmedAccount= false; //Hesap onayı

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

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

            //Kimlik doğrulama
            app.UseAuthentication();

            //yetkilendirme işlemi
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}