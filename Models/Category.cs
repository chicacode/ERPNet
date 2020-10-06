using ERPNet.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace EmployeeWebMySQL.Models
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength ( 50 )]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
       
    }
}
