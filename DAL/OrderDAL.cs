using DAL.Context;
using DAL.Interfaces;
using Models;

namespace DAL
{
    public class OrderDAL : IOrderDAL
    {
        public Order CreateOrder(Order order)
        {
            using (var context = new OnlineStoreContext())
            {
                context.Add(order);
                context.SaveChanges();
                return order;
            }
        }

        public Order GetOrderById(string orderID)
        {
            using (var context = new OnlineStoreContext())
            {
                Order order = context.Orders
                    .Where(p => p.OrderID.Equals(orderID))
                    .Select(o => new Order
                    {
                        OrderID = o.OrderID,
                        ProductID = o.ProductID,
                        OrderDate = o.OrderDate,
                        ShippingDate = o.ShippingDate,
                        Status = o.Status,
                    }).First();

                return order;
            }

            return null;
        }

        public Order UpdateOrderStatus(string orderID, string status)
        {
            using (var context = new OnlineStoreContext())
            {
                Order order = context.Orders.FirstOrDefault(p => p.OrderID.Equals(orderID));

                if (order != null)
                {
                    order.Status = status;
                    context.SaveChanges();
                    return order;
                }

                return null;
            }
        }
    }
}
