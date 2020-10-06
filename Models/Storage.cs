using ERPNet.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EmployeeWebMySQL.Models
{
    public class Storage : IEntity
    {
        public int Id { get; set; }
        public DateTime LastUpdate { get; set; }
        public int PartialQuantity { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }

        [JsonIgnore]
        public ICollection<Movements> InputOutputs { get; set; }
      
    }
}
