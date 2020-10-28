using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace ERPNet.Models
{
    public class Customer : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength ( 50 )]
        public string Name { get; set; }

        [StringLength ( 50 )]
        public string LastName { get; set; }

        [StringLength ( 50 )]
        public string PhoneNumber { get; set; }

        [StringLength ( 50 )]
        public string Email { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }

        [JsonIgnore]
        public virtual ICollection<Address> Addresses { get; set;  }
      
    }
}
