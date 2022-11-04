using DAL.Context;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class ProductDAL : IProductDAL
    {
        public Product CreateProduct(Product product)
        {
            using (var context = new OnlineStoreContext())
            {
                context.Add(product);
                context.SaveChanges();
                return product;
            }
        }

        public Product UploadImage(string productID, string image)
        {
            using (var context = new OnlineStoreContext())
            {
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
                Product product = context.Products.FirstOrDefault(p => p.ProductID.Equals(productID));

                if (product != null)
                {
                    return product.Image;
                }

                return null;
            }
        }

        public Product GetProductById(string productID)
        {
            try
            {
                using (var context = new OnlineStoreContext())
                {
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
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
            }

            return null;
        }

        public Product UpdateProduct(string productID, Product product)
        {
            using (var context = new OnlineStoreContext())
            {
                product = context.Products.FirstOrDefault(p => p.ProductID.Equals(productID));

                if (product != null)
                {
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                    return product;
                }

                return null;
            }
        }
    }
}
