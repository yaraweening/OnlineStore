using Microsoft.AspNetCore.Http;
using Models;

namespace DAL.Interfaces
{
    public interface IProductDAL
    {
        Product CreateProduct(Product product);
        Product UploadImage(string productID, string image);

        string DownloadImage(string productID);
        Product GetProductById(string productID);
        Product UpdateProduct(string productID, Product product);
    }
}
