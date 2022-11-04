using Newtonsoft.Json.Serialization;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Resolvers;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;

namespace Models.ExampleGenerators
{
    public class ForumExampleGenerator : OpenApiExample<Forum>
    {
        public override IOpenApiExample<Forum> Build(NamingStrategy NamingStrategy = null)
        {
            Examples.Add(OpenApiExampleResolver.Resolve("Order", instance: new Forum()
            {
                ForumID = "Forum-01",
                Review = "I am very satisfied with the new MSI laptop."
            }, NamingStrategy));
            return this;
        }
    }
}
