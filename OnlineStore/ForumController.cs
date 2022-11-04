using System.Net;
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

namespace OnlineStore
{
    public class ForumController
    {
        private ILogger Logger { get; }
        private readonly IForumService _forumService;

        public ForumController(ILogger<ForumController> log, IForumService forumService)
        {
            Logger = log;
            _forumService = forumService;
        }

        [Function("CreateForum")]
        [OpenApiOperation(operationId: "CreateForum", tags: new[] { "Forum" }, Description = "Create Forum")]
        [OpenApiRequestBody("application/json", typeof(Forum), Description = "The forum data.", Example = typeof(ForumExampleGenerator))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(Forum), Description = "The OK response with the new forum.", Example = typeof(ForumExampleGenerator))]
        public IActionResult CreateProduct([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Forum")] HttpRequestData req)
        {
            Logger.LogInformation("Creating new forum.");

            try
            {
                string requestBody = new StreamReader(req.Body).ReadToEnd();
                Forum data = JsonConvert.DeserializeObject<Forum>(requestBody);

                _forumService.CreateForum(data);

                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [Function("GetReviews")]
        [OpenApiOperation(operationId: "GetReviews", tags: new[] { "Review" }, Description = "Get reviews")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IEnumerable<Forum>), Description = "The OK response with the reviews.", Example = typeof(ForumExampleGenerator))]
        public IActionResult GetReviews([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Reviews")] HttpRequestData req)
        {
            try
            {
                return _forumService.GetReviewsFromForums();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
