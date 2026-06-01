using CoffeShop.Data;
using CoffeShop.Models.Interfaces;
using CoffeShop.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CoffeShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Section 2: Connect Entity Framework Core and MSSQL
            builder.Services.AddDbContext<CoffeeshopDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeShopDbContextConnection")));

            // Section 1: Registering Services in IOC Container
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession();
            builder.Services.AddScoped<IShoppingCartRepository>(sc => ShoppingCartRepository.GetCart(sc));
            // Đăng ký dịch vụ cho tầng Repository xử lý đơn hàng
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            // MVC
            builder.Services.AddControllersWithViews();


            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<CoffeeshopDbContext>();

            builder.Services.AddRazorPages();
            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            app.UseAuthentication(); //code

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();
            app.Run();
        }
    }
}
