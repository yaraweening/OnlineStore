using DAL;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models;
using Services.Interfaces;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderDAL _orderDAL;

        public OrderService(IOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }

        public Order CreateOrder(Order order)
        {
            order = new Order
            {
                OrderID = order.OrderID,
                ProductID = order.ProductID,
                OrderDate = order.OrderDate,
                ShippingDate = order.ShippingDate,
                Status = order.Status
            };

            order = _orderDAL.CreateOrder(order);

            return order;
        }

        public IActionResult GetOrderById(string orderID)
        {
            return (new ActionResult<Order>(_orderDAL.GetOrderById(orderID)) as IConvertToActionResult).Convert();
        }

        public IActionResult UpdateOrderStatus(string orderNumber, string status)
        {
            return (new ActionResult<Order>(_orderDAL.UpdateOrderStatus(orderNumber, status)) as IConvertToActionResult).Convert();
        }
    }
}
