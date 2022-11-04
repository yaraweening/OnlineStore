using Models;

namespace DAL.Interfaces
{
    public interface IOrderDAL
    {
        Order CreateOrder(Order order);
        IEnumerable<Order> GetOrders();
        Order GetOrderById(string orderID);
        Order UpdateOrderStatus(string orderID, string status);
    }
}
