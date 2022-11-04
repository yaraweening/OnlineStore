using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Order
    {
        [StringLength(150)]
        [JsonRequired]
        public string OrderID { get; set; }
        [StringLength(150)]
        [JsonRequired]
        public string ProductID { get; set; }
        [JsonRequired]
        public DateTime OrderDate { get; set; }
        [JsonRequired]
        public DateTime ShippingDate { get; set; }
        [JsonRequired]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
