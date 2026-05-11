using CoffeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Controllers
{
    public class ProductsController : Controller
    {
        // Sử dụng tên biến giống hệt đề bài: productRepository (không có dấu gạch dưới)
        private IProductRepository productRepository;

        // Constructor tiêm Repository vào (Dependency Injection)
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // ĐỔI TÊN HÀM: Từ Index() thành Shop() để khớp với file Shop.cshtml và đề bài
        public IActionResult Shop()
        {
            // Gọi hàm lấy danh sách sản phẩm
            var products = productRepository.GetAllProducts();

            // Trả về View mang tên Shop.cshtml cùng với dữ liệu products
            return View(products);
        }

        // Giữ lại Detail để sử dụng cho trang chi tiết sau này
        public IActionResult Detail(int id)
        {
            var product = productRepository.GetProductDetail(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}