using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeWebMySQL.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }

        [Required]
        [StringLength ( 100 )]
        public string Name { get; set; }
        public string Address { get; set; }

        [JsonIgnore]
        public ICollection<Storage> Storages { get; set; }
    }
}
