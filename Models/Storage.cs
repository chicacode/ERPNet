using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeWebMySQL.Models
{
    public class Storage
    {
        [Key]
        public int StorageId { get; set; }
        public DateTime LastUpdate { get; set; }
        public int PartialQuantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        [JsonIgnore]
        public ICollection<Movements> InputOutputs { get; set; }
    }
}
