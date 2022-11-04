using Newtonsoft.Json.Serialization;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Resolvers;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;

namespace Models.ExampleGenerators
{
    public class ProductExampleGenerator : OpenApiExample<Product>
    {
        public override IOpenApiExample<Product> Build(NamingStrategy NamingStrategy = null)
        {
            Examples.Add(OpenApiExampleResolver.Resolve("Product", instance: new Product()
            {
                ProductID = "Product-01",
                Name = "MSI laptop",
                Description = "MSI Laptop has a fast processor for gaming",
                Image = "msi.jpg"
            }, NamingStrategy));
            return this;
        }
    }
}
