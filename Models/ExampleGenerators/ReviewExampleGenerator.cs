using Newtonsoft.Json.Serialization;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Resolvers;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;

namespace Models.ExampleGenerators
{
    public class ReviewExampleGenerator : OpenApiExample<Review>
    {
        public override IOpenApiExample<Review> Build(NamingStrategy NamingStrategy = null)
        {
            Examples.Add(OpenApiExampleResolver.Resolve("Review", instance: new Review()
            {
                ReviewID = "Review-01",
                ProductID = "Product-01",
                ReviewText = "I am very satisfied with the new MSI laptop."
            }, NamingStrategy));
            return this;
        }
    }
}
