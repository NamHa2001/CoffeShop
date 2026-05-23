using CoffeShop.Models.ViewModel;

namespace CoffeShop.Models.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(string? searchString = null, string? type = null);
        IEnumerable<Product> GetTrendingProducts();
        Product? GetProductById(int id);
        void AddProduct(VMProduct model);
        void UpdateProduct(int id, VMProduct model);
        void DeleteProduct(int id);
    }
}
