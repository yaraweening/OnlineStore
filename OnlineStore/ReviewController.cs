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
    public class ReviewController
    {
        private ILogger Logger { get; }
        private readonly IReviewService _reviewService;

        public ReviewController(ILogger<ReviewController> log, IReviewService reviewService)
        {
            Logger = log;
            _reviewService = reviewService;
        }

        [Function("CreateReview")]
        [OpenApiOperation(operationId: "CreateReview", tags: new[] { "Review" }, Description = "Create review")]
        [OpenApiRequestBody("application/json", typeof(Review), Description = "The review data.", Example = typeof(ReviewExampleGenerator))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(Review), Description = "The OK response with the new review.", Example = typeof(ReviewExampleGenerator))]
        public IActionResult CreateProduct([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Review")] HttpRequestData req)
        {
            Logger.LogInformation("Creating new review.");

            try
            {
                string requestBody = new StreamReader(req.Body).ReadToEnd();
                Review data = JsonConvert.DeserializeObject<Review>(requestBody);

                _reviewService.CreateReview(data);

                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [Function("GetReviews")]
        [OpenApiOperation(operationId: "GetReviews", tags: new[] { "Review" }, Description = "Get reviews")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IEnumerable<Review>), Description = "The OK response with the reviews.", Example = typeof(ReviewExampleGenerator))]
        public IActionResult GetReviews([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Reviews")] HttpRequestData req)
        {
            try
            {
                return _reviewService.GetReviews();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
