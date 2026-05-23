using CoffeShop.Data;
using CoffeShop.Models.Interfaces;
using CoffeShop.Models.ViewModel;

namespace CoffeShop.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly CoffeshopDbContext _dbContext;

        public ProductRepository(CoffeshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAll(string? searchString = null, string? type = null)
        {
            if (!string.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                var list = from p in _dbContext.Products select p; // lấy toàn bộ liên kết
                if (type == "Detail")
                {
                    return list.Where(p => p.Detail!.Contains(searchString)); // lọc theo mô tả
                }
                else
                {
                    return list.Where(p => p.Name!.Contains(searchString)); // lọc theo tên
                }
            }
            else
            {
                return _dbContext.Products;
            }
        }

        public IEnumerable<Product> GetTrendingProducts()
        {
            return _dbContext.Products.Where(p => p.IsTrendingProduct);
        }

        public Product? GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(VMProduct model)
        {
            bool isTrending = model.IsTrendingProduct == "true";
            var product = new Product
            {
                Name = model.Name,
                Detail = model.Detail,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                IsTrendingProduct = isTrending
            };
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(int id, VMProduct model)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Detail = model.Detail;
                product.ImageUrl = model.ImageUrl;
                product.Price = model.Price;
                product.IsTrendingProduct = model.IsTrendingProduct == "true";
                _dbContext.Update(product);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
        }
    }
}
