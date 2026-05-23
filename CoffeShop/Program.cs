using CoffeShop.Data;
using CoffeShop.Models.Services;
using CoffeShop.Models.Interfaces;
using CoffeShop.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // EF Core – DB sản phẩm
            builder.Services.AddDbContext<CoffeshopDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeShopDbContextConnection")));

            // EF Core – DB Identity (xác thực & phân quyền)
            builder.Services.AddDbContext<AuthenDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("AuthenDbContextConnection")));

            // Identity
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AuthenDbContext>()
                .AddDefaultTokenProviders();

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            // Repository
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            // MVC
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // Phải có UseAuthentication TRƯỚC UseAuthorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
