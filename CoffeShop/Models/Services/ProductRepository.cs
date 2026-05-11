
using CoffeShop.Models;
using CoffeShop.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CoffeShop.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        // Tạo mảng dữ liệu giả vì chưa có database
        private List<Product> ProductsList = new List<Product>()
        {
            new Product{ Id = 1, Name = "America", Price = 25, Detail="Name product", ImageUrl="https://index.com", IsTrendingProduct = true},
            new Product{ Id = 2, Name = "Vietnam", Price = 20, Detail="Vietnamese product", ImageUrl="https://index.com", IsTrendingProduct = false},
            new Product{ Id = 3, Name = "United Kingdom", Price = 15, Detail="Name product", ImageUrl="https://index.com", IsTrendingProduct = true}
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return ProductsList;
        }

        public Product? GetProductDetail(int id)
        {
            return ProductsList.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetTrendingProducts()
        {
            return ProductsList.Where(p => p.IsTrendingProduct);
        }
    }
}