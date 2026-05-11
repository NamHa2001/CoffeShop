using CoffeShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.Data
{
    public class CoffeshopDbContext : DbContext
    {
        public CoffeshopDbContext(DbContextOptions<CoffeshopDbContext> options) : base(options)
        {
        }

        // Khai báo bảng Products trong Database
        public DbSet<Product> Products { get; set; }
    }
}