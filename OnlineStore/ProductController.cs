using System.Net;
using Microsoft.AspNetCore.Http;
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
    public class ProductController
    {
        private ILogger Logger { get; }
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> log, IProductService productService)
        {
            Logger = log;
            _productService = productService;
        }

        [Function("CreateProduct")]
        [OpenApiOperation(operationId: "CreateProduct", tags: new[] { "Product" }, Description = "Create product")]
        [OpenApiRequestBody("application/json", typeof(ProductDto), Description = "The product data.", Example = typeof(ProductExampleGenerator))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(ProductDto), Description = "The OK response with the new product.", Example = typeof(ProductExampleGenerator))]        
        public IActionResult CreateProduct([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Product")] HttpRequestData req)
        {
            Logger.LogInformation("Creating new product.");

            try
            {
                string requestBody = new StreamReader(req.Body).ReadToEnd();
                ProductDto data = JsonConvert.DeserializeObject<ProductDto>(requestBody);

                return _productService.CreateProduct(data);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [Function("UploadImage")]
        [OpenApiOperation(operationId: "UploadImage", tags: new[] { "Product" }, Description = "Create product")]
        [OpenApiRequestBody(contentType: "multipart/form-data", bodyType: typeof(MultiPartFormData), Required = true, Description = "Image data")]
        [OpenApiParameter("ProductID", Description = "The product data.", Required = true, In = ParameterLocation.Path)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Product), Description = "The OK response with the new product.", Example = typeof(ProductExampleGenerator))]
        public IActionResult UploadImage([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "ImageUpload/{ProductID}")] HttpRequestData req, string productID)
        {
            Logger.LogInformation("Uploading new image.");

            try
            {
                var image = Convert.ToBase64String((req.Body as MemoryStream).ToArray());
                return _productService.UploadImage(productID, image);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [Function("DownloadImage")]
        [OpenApiOperation(operationId: "DownloadImage", tags: new[] { "byte[]" }, Description = "Get specific product")]
        [OpenApiParameter("ProductID", Description = "The product data.", Required = true, In = ParameterLocation.Path)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "image/jpg", bodyType: typeof(byte[]), Description = "The OK response with the specific product.")]
        public IActionResult DownloadImage([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ImageDownload/{ProductID}")] HttpRequestData req, string productID)
        {
            try
            {
                return _productService.DownloadImage(productID);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [Function("GetProduct")]
        [OpenApiOperation(operationId: "GetProduct", tags: new[] { "Product" }, Description = "Get specific product")]
        [OpenApiParameter("ProductID", Description = "The product data.", Required = true, In = ParameterLocation.Path)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Product), Description = "The OK response with the specific product.", Example = typeof(ProductExampleGenerator))]
        public IActionResult GetProductById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Product/{ProductID}")] HttpRequestData req, string productID)
        {
            try
            {
                return _productService.GetProductById(productID);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [Function("UpdateProduct")]
        [OpenApiOperation(operationId: "UpdateProduct", tags: new[] { "Product" }, Description = "Update product")]
        [OpenApiParameter("ProductID", Description = "The product data.", Required = true, In = ParameterLocation.Path)]
        [OpenApiRequestBody("application/json", typeof(Product), Description = "The product data.", Example = typeof(ProductExampleGenerator))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Product), Description = "The OK response with the updated product.", Example = typeof(ProductExampleGenerator))]
        public IActionResult UpdateProduct([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Product/{ProductID}")] HttpRequestData req, string productID, Product product)
        {
            try
            {
                return _productService.UpdateProduct(productID, product);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}

