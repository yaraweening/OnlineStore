using DAL.Context;
using DAL.Interfaces;
using Models;

namespace DAL
{
    public class ProductDAL : IProductDAL
    {
        public Product CreateProduct(Product product)
        {
            using (var context = new OnlineStoreContext())
            {
                if (ProductExists(product.ProductID))
                {
                    throw new Exception("This product id already exists");
                }

                context.Add(product);
                context.SaveChanges();
                return product;
            }
        }

        public Product UploadImage(string productID, string image)
        {
            using (var context = new OnlineStoreContext())
            {
                if (!ProductExists(productID))
                {
                    throw new Exception("This product does not exist");
                }

                Product product = context.Products.FirstOrDefault(p => p.ProductID.Equals(productID));

                if (product != null)
                {
                    product.Image = image;
                    context.SaveChanges();
                    return product;
                }

                return null;
            }
        }

        public string DownloadImage(string productID)
        {
            using (var context = new OnlineStoreContext())
            {
                if (!ProductExists(productID))
                {
                    throw new Exception("This product does not exist");
                }

                Product product = context.Products.FirstOrDefault(p => p.ProductID.Equals(productID));

                if (product != null)
                {
                    return product.Image;
                }

                return null;
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var context = new OnlineStoreContext())
            {
                return context.Products.ToList();
            }

            return null;
        }

        public Product GetProductById(string productID)
        {
            using (var context = new OnlineStoreContext())
            {
                if (!ProductExists(productID))
                {
                    throw new Exception("This product does not exist");
                }

                Product product = context.Products
                    .Where(p => p.ProductID.Equals(productID))
                    .Select(o => new Product
                    {
                        ProductID = o.ProductID,
                        Name = o.Name,
                        Description = o.Description
                    }).First();

                return product;
            }

            return null;
        }

        private static bool ProductExists(string productID)
        {
            using (var context = new OnlineStoreContext())
            {
                return context.Products.Any(e => e.ProductID == productID);
            }
        }
    }
}
