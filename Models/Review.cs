using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Review
    {
        [StringLength(150)]
        [JsonRequired]
        public string ReviewID { get; set; }
        [StringLength(150)]
        [JsonRequired]
        public string ProductID { get; set; }
        [StringLength(450)]
        [JsonRequired]
        public string ReviewText { get; set; }
    }
}
