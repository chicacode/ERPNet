using ERPNet.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace EmployeeWebMySQL.Models
{
    public class Warehouse : IEntity
    {
        public int Id { get; set; }
        [Required]
        [StringLength ( 100 )]
        public string Name { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        [JsonIgnore]
        public ICollection<Storage> Storages { get; set; }
      
    }
}
