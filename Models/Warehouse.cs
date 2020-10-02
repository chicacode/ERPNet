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
        public int WarehouseId { get; set; }

        [Required]
        [StringLength ( 100 )]
        public string Name { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        [JsonIgnore]
        public ICollection<Storage> Storages { get; set; }
    }
}
