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
                if (!ProductExists(order.ProductID))
                {
                    throw new Exception("This product does not exist");
                }

                if (OrderExists(order.OrderID))
                {
                    throw new Exception("This order id already exists");
                }

                context.Add(order);
                context.SaveChanges();
                return order;
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            using (var context = new OnlineStoreContext())
            {
                return context.Orders.ToList();
            }

            return null;
        }

        public Order GetOrderById(string orderID)
        {
            using (var context = new OnlineStoreContext())
            {
                if (!OrderExists(orderID))
                {
                    throw new Exception("This order does not exist");
                }

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
                if (!OrderExists(orderID))
                {
                    throw new Exception("This order does not exist");
                }

                Order order = context.Orders.FirstOrDefault(p => p.OrderID.Equals(orderID));

                if (order != null)
                {
                    order.Status = status;
                    order.ShippingDate = DateTime.Now;
                    context.SaveChanges();
                    return order;
                }

                return null;
            }
        }

        private static bool ProductExists(string productID)
        {
            using (var context = new OnlineStoreContext())
            {
                return context.Products.Any(e => e.ProductID == productID);
            }
        }

        private static bool OrderExists(string orderID)
        {
            using (var context = new OnlineStoreContext())
            {
                return context.Orders.Any(e => e.OrderID == orderID);
            }
        }
    }
}
