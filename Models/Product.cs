using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace ERPNet.Models
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

        [Required]
        [StringLength ( 50 )]
        public string CategoryName { get; set; }

        [JsonIgnore]
        public ICollection<Storage> Storages { get; set; }
      
    }
}
