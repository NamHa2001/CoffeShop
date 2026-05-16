using CoffeShop.Models.Services;
using CoffeShop.Models.Interfaces;
using CoffeShop.Data;
using Microsoft.EntityFrameworkCore;
namespace CoffeShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //builder.Services.AddDbContext<CoffeshopDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeShopDbContextConnection")));
            // Đăng ký Interface và Repository

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
