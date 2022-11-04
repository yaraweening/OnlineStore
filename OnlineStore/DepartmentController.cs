using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Models.ExampleGenerators;
using Models;
using System.Net;
using Services.Interfaces;
using Newtonsoft.Json;

namespace OnlineStore
{
    public class DepartmentController
    {
        private ILogger Logger { get; }
        private readonly IDepartmentService _departmentService;

        public DepartmentController(ILogger<DepartmentController> log, IDepartmentService departmentService)
        {
            Logger = log;
            _departmentService = departmentService;
        }

        [Function("CreateDepartment")]
        [OpenApiOperation(operationId: "CreateDepartment", tags: new[] { "Department" }, Description = "Create department")]
        [OpenApiRequestBody("application/json", typeof(Department), Description = "The department data.", Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(Department), Description = "The OK response with the new department.", Example = typeof(DepartmentExampleGenerator))]
        public IActionResult CreateDepartment([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Department")] HttpRequestData req)
        {
            Logger.LogInformation("Creating new department.");

            try
            {
                string requestBody = new StreamReader(req.Body).ReadToEnd();
                Department data = JsonConvert.DeserializeObject<Department>(requestBody);

                _departmentService.CreateDepartment(data);

                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
