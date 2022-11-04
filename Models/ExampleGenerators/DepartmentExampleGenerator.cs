using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Resolvers;
using Newtonsoft.Json.Serialization;

namespace Models.ExampleGenerators
{
    public class DepartmentExampleGenerator : OpenApiExample<Department>
    {
        public override IOpenApiExample<Department> Build(NamingStrategy NamingStrategy = null)
        {
            Examples.Add(OpenApiExampleResolver.Resolve("Department", instance: new Department()
            {
                DepartmentID = "Department-01",
                Name = "Wiley and Co"
            }, NamingStrategy));
            return this;
        }
    }
}
