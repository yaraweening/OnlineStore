using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
