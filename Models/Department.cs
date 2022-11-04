using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Department
    {
        [StringLength(150)]
        [JsonRequired]
        public string DepartmentID { get; set; }
        [StringLength(100)]
        [JsonRequired]
        public string Name { get; set; }
    }
}
