using CoffeShop.Models;
using CoffeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CoffeShop.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private IOrderRepository orderRepository;
        private IShoppingCartRepository shoppingCartRepository;
        public OrdersController(IOrderRepository oderRepository,
       IShoppingCartRepository shoppingCartRepossitory)
        {
            this.orderRepository = oderRepository;
            this.shoppingCartRepository = shoppingCartRepossitory;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            orderRepository.PlaceOrder(order);
            shoppingCartRepository.ClearCart();
            HttpContext.Session.SetInt32("CartCount", 0);
            return RedirectToAction("CheckoutComplete");
        }

        public IActionResult CheckoutComplete()
        {
            return View();
        }

        public IActionResult ListOrders()
        {
            // Lấy Email của người dùng đang đăng nhập (trong Identity mặc định Name chính là Email)
            var userEmail = User.Identity.Name;

            // Gọi hàm trong Repository để lấy danh sách đơn hàng của người này
            var userOrders = orderRepository.GetUserOrders(userEmail);

            // Truyền danh sách sang View để hiển thị
            return View(userOrders);
        }
    }
}
