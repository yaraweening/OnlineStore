using Models;

namespace DAL.Interfaces
{
    public interface IProductDAL
    {
        Product CreateProduct(Product product);
        Product UploadImage(string productID, string image);
        string DownloadImage(string productID);
        IEnumerable<Product> GetProducts();
        Product GetProductById(string productID);
    }
}
