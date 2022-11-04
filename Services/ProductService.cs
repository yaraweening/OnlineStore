using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models;
using Services.Interfaces;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDAL _productDAL;

        public ProductService(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public IActionResult CreateProduct(ProductDto productDto)
        {
            var product = _productDAL.CreateProduct(productDto.ToProduct());
            return (new ActionResult<ProductDto>(product.ToProductDto()) as IConvertToActionResult).Convert();
        }

        public IActionResult UploadImage(string productID, string image)
        {
            return (new ActionResult<Product>(_productDAL.UploadImage(productID, image)) as IConvertToActionResult).Convert();
        }

        public IActionResult DownloadImage(string productID)
        {
            var image = _productDAL.DownloadImage(productID);
            var imageBytes = Convert.FromBase64String(image);
            var result = new FileContentResult(imageBytes, "image/jpg");

            return result;
        }

        public IActionResult GetProducts()
        {
            var products = _productDAL.GetProducts().Select(p => new ProductDto
            {
                ProductID = p.ProductID,
                Name = p.Name,
                Description = p.Description,
            });

            return (new ActionResult<IEnumerable<ProductDto>>(products) as IConvertToActionResult).Convert();
        }

        public IActionResult GetProductById(string productID)
        {
            return (new ActionResult<ProductDto>(_productDAL.GetProductById(productID).ToProductDto()) as IConvertToActionResult).Convert();
        }
    }
}
