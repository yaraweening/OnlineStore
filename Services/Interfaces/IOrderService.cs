using Microsoft.AspNetCore.Mvc;
using Models;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        Order CreateOrder(Order order);
        IActionResult GetOrderById(string orderID);
        IActionResult UpdateOrderStatus(string orderID, string status);
    }
}
