namespace CoffeShop.Models.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetUserOrders(string email);
        void PlaceOrder(Order order);
    }
}
