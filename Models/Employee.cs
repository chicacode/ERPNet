
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace ERPNet.Models
{
    public class Employee : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength ( 50 )]
        public string Name { get; set; }

        [StringLength ( 50 )]
        public string LastName { get; set; }

        [StringLength ( 50 )]
        public string PositionJob { get; set; }
        public int Salary { get; set; }

        [StringLength ( 50 )]
        public string UserName { get; set; }

        [StringLength ( 50 )]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
        [JsonIgnore]
        public virtual ICollection<Address> Addresses { get; set; }

    }
}
