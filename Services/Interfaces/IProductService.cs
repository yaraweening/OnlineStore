using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Services.Interfaces
{
    public interface IProductService
    {
        IActionResult CreateProduct(ProductDto product);
        IActionResult UploadImage(string productID, string image);
        IActionResult DownloadImage(string productID);
        IActionResult GetProductById(string productID);
        IActionResult UpdateProduct(string productID, Product product);
    }
}
