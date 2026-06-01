using CoffeShop.Data;
using CoffeShop.Models.Interfaces;

using Microsoft.EntityFrameworkCore;
namespace CoffeShop.Models.Services
{
    public class OrderRepository : IOrderRepository
    {
        private CoffeeshopDbContext dbContext;
        private IShoppingCartRepository shoppingCartRepository;

        public OrderRepository(CoffeeshopDbContext dbContext, IShoppingCartRepository shoppingCartRepository)
        {
            this.dbContext = dbContext;
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public IEnumerable<Order> GetUserOrders(string email)
        {
            return dbContext.Order
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product) // Nối bảng để lấy được tên và ảnh sản phẩm
                .Where(o => o.Email == email)
                .OrderByDescending(o => o.OrderPlaced) // Xếp đơn hàng mới nhất lên đầu
                .ToList();
        }
        public void PlaceOrder(Order order)
        {
            var shoppingCartItems = shoppingCartRepository.GetAllShoppingCartItems();
            order.OrderDetails = new List<OrderDetail>();
            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Quantity = item.Qty,
                    ProductId = item.Product.Id,
                    Price = item.Product.Price
                };
                order.OrderDetails.Add(orderDetail);
            }

            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = shoppingCartRepository.GetShoppingCartTotal();
            dbContext.Order.Add(order);
            dbContext.SaveChanges();
        }
    }
}
