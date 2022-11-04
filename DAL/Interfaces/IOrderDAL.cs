using Microsoft.AspNetCore.Mvc;
using Models;

namespace DAL.Interfaces
{
    public interface IOrderDAL
    {
        Order CreateOrder(Order order);
        Order GetOrderById(string orderID);
        Order UpdateOrderStatus(string orderID, string status);
    }
}
