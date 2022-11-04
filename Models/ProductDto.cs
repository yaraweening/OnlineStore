using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProductDto
    {
        [StringLength(150)]
        [JsonRequired]
        public string ProductID { get; set; }
        [StringLength(100)]
        [JsonRequired]
        public string Name { get; set; }
        [StringLength(450)]
        [JsonRequired]
        public string Description { get; set; }

        public Product ToProduct()
        {
            return new Product
            {
                ProductID = this.ProductID,
                Description = this.Description,
                Name = this.Name,
                Image = String.Empty,
            };
        }
    }
}
