using CoffeShop.Data;
using CoffeShop.Models.Interfaces;
using CoffeShop.Models.Services;
using Microsoft.EntityFrameworkCore;

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

            // MVC
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
