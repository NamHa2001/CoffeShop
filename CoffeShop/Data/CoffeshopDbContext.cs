using CoffeShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.Data
{
    public class CoffeshopDbContext : DbContext
    {
        public CoffeshopDbContext(DbContextOptions<CoffeshopDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Cà phê đen",
                    Detail = "Cà phê đen đậm đà truyền thống Việt Nam, pha phin thủ công.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/45/A_small_cup_of_coffee.JPG",
                    Price = 25000,
                    IsTrendingProduct = true
                },
                new Product
                {
                    Id = 2,
                    Name = "Cà phê sữa",
                    Detail = "Cà phê phin kết hợp sữa đặc ngọt ngào, hương vị đặc trưng.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/45/A_small_cup_of_coffee.JPG",
                    Price = 30000,
                    IsTrendingProduct = true
                },
                new Product
                {
                    Id = 3,
                    Name = "Bạc xỉu",
                    Detail = "Cà phê sữa tỉ lệ sữa nhiều hơn, nhẹ nhàng và béo ngậy.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/45/A_small_cup_of_coffee.JPG",
                    Price = 32000,
                    IsTrendingProduct = false
                },
                new Product
                {
                    Id = 4,
                    Name = "Cappuccino",
                    Detail = "Espresso pha với sữa nóng đánh bọt mịn, phong cách Ý.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/45/A_small_cup_of_coffee.JPG",
                    Price = 55000,
                    IsTrendingProduct = true
                },
                new Product
                {
                    Id = 5,
                    Name = "Latte",
                    Detail = "Espresso với lượng lớn sữa nóng, vị nhẹ và thơm.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/45/A_small_cup_of_coffee.JPG",
                    Price = 60000,
                    IsTrendingProduct = false
                },
                new Product
                {
                    Id = 6,
                    Name = "Cold Brew",
                    Detail = "Cà phê ủ lạnh 12 giờ, vị đậm mượt mà không chua.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/45/A_small_cup_of_coffee.JPG",
                    Price = 65000,
                    IsTrendingProduct = true
                }
            );
        }
    }
}

