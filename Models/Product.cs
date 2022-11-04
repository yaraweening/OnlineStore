using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Product
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
        [JsonRequired]
        public string Image { get; set; }

        public ProductDto ToProductDto()
        {
            return new ProductDto
            {
                ProductID = this.ProductID,
                Description = this.Description,
                Name = this.Name,
            };
        }
    }
}
