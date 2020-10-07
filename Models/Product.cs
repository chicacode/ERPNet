using ERPNet.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace EmployeeWebMySQL.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
   
        [Required]
        [StringLength ( 100 )]
        public string Name { get; set; }

        [StringLength ( 300 )]
        public string Description { get; set; }
        public int TotalQuantity { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [JsonIgnore]
        public ICollection<Storage> Storages { get; set; }
      
    }
}
