using CoffeShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.Data
{
    public class CoffeeshopDbContext : DbContext
    {
        public CoffeeshopDbContext(DbContextOptions<CoffeeshopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        // seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Name = "America",
                   Price = 25,
                   Detail = "A bold and rich espresso-based coffee...",
                   ImageUrl = "/assets/images/mohammad-amirahmadi-tk2ifgn60xo-unsplash-815x1019.jpg",
                   IsTrendingProduct = true
               },

                new Product
                {
                    Id = 2,
                    Name = "Vietnam",
                    Price = 20,
                    Detail = "Vietnamese coffee is known for its intense flavor...",
                    ImageUrl = "/assets/images/nathan-dumlao-nbjho6wmrww-unsplash-815x1223.jpg",
                    IsTrendingProduct = true
                },

                new Product
                {
                    Id = 3,
                    Name = "United Kingdom",
                    Price = 15,
                    Detail = "A classic British-style coffee blend...",
                    ImageUrl = "/assets/images/anna-bratiychuk-3w2aurzeesu-unsplash-815x1223.jpg",
                    IsTrendingProduct = true
                },

                new Product
                {
                    Id = 4,
                    Name = "India",
                    Price = 15,
                    Detail = "Indian filter coffee is a traditional South Indian beverage...",
                    ImageUrl = "/assets/images/jeremy-yap-jn-hagwe4yw-unsplash-815x1223.jpg"
                },

                new Product
                {
                    Id = 5,
                    Name = "Russian",
                    Price = 25,
                    Detail = "A unique coffee blend inspired by Russian traditions...",
                    ImageUrl = "/assets/images/tetiana-shyshkina-4lqjr8gu-bg-unsplash-815x1222.jpg"
                },

                new Product
                {
                    Id = 6,
                    Name = "France",
                    Price = 35,
                    Detail = "French roast coffee is characterized by its dark, smoky flavor...",
                    ImageUrl = "/assets/images/giancarlo-duarte-rthw0pwclhw-unsplash-815x543.jpg"
                }
            );
        }
    }
}
