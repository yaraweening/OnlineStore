using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Models;
using Models.ExampleGenerators;
using Newtonsoft.Json;
using Services.Interfaces;
using System.Net;

namespace OnlineStore
{
    public class OrderController
    {
        private ILogger Logger { get; }
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> log, IOrderService ordersService)
        {
            Logger = log;
            _orderService = ordersService;
        }

        [Function("CreateOrder")]
        [OpenApiOperation(operationId: "CreateOrder", tags: new[] { "Order" }, Description = "Create an order")]
        [OpenApiRequestBody("application/json", typeof(Order), Description = "The order data.", Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Order), Description = "The OK response for adding an order.", Example = typeof(OrderExampleGenerator))]
        public IActionResult CreateOrder([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Order")] HttpRequestData req)
        {
            try
            {
                string requestBody = new StreamReader(req.Body).ReadToEnd();
                Order data = JsonConvert.DeserializeObject<Order>(requestBody);

                _orderService.CreateOrder(data);

                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [Function("GetOrders")]
        [OpenApiOperation(operationId: "GetOrders", tags: new[] { "Order" }, Description = "Get orders")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IEnumerable<Order>), Description = "The OK response with the orders.", Example = typeof(OrderExampleGenerator))]
        public IActionResult GetOrders([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Orders")] HttpRequestData req)
        {
            try
            {
                return _orderService.GetOrders();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [Function("GetOrder")]
        [OpenApiOperation(operationId: "GetOrder", tags: new[] { "Order" }, Description = "Get specific order")]
        [OpenApiParameter("OrderID", Description = "The order data.", Required = true, In = ParameterLocation.Path)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Order), Description = "The OK response with a specific order.", Example = typeof(OrderExampleGenerator))]
        public IActionResult GetOrderById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Order/{OrderID}")] HttpRequestData req, string orderID)
        {
            try
            {
                return _orderService.GetOrderById(orderID);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [Function("UpdateOrder")]
        [OpenApiOperation(operationId: "UpdateOrder", tags: new[] { "Order" }, Description = "Update status of order")]
        [OpenApiParameter("OrderID", Description = "The order data.", Required = true, In = ParameterLocation.Path)]
        [OpenApiParameter("Status", Description = "The new order status", Required = true, In = ParameterLocation.Path)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Order), Description = "The OK response with the updated order status.", Example = typeof(OrderExampleGenerator))]
        public IActionResult UpdateOrderStatus([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Orders/{OrderID}/{Status}")] HttpRequestData req, string orderID, string status)
        {
            try
            {
                return _orderService.UpdateOrderStatus(orderID, status);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
