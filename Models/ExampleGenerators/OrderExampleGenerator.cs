using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Resolvers;
using Newtonsoft.Json.Serialization;

namespace Models.ExampleGenerators
{
    public class OrderExampleGenerator : OpenApiExample<Order>
    {
        public override IOpenApiExample<Order> Build(NamingStrategy NamingStrategy = null)
        {
            Examples.Add(OpenApiExampleResolver.Resolve("Order", instance: new Order()
            { 
                OrderID = "Order-01",
                ProductID = "Product-01",
                OrderDate = new DateTime(2022, 12, 24),
                ShippingDate = new DateTime(2022, 12, 30),
                Status = "Not shipped"
            }, NamingStrategy));
            return this;
        }
    }
}
