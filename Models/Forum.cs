using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Forum
    {
        [StringLength(150)]
        [JsonRequired]
        public string ForumID { get; set; }
        [StringLength(450)]
        [JsonRequired]
        public string Review { get; set; }
    }
}
