using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ERPNet.Models
{
    public class Storage : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }

        [Required]
        public int PartialQuantity { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }

        [JsonIgnore]
        public ICollection<Movements> InputOutputs { get; set; }
      
    }
}
