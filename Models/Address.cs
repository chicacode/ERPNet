using ERPNet.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace ERPNet.Models
{
    public class Address : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int AddressNumber { get; set; }

        [StringLength ( 50 )]
        public string AddressStreet { get; set; }

        [StringLength ( 50 )]
        public string AddressContactName { get; set; }

        [StringLength ( 20 )]
        public string AddressZipCode { get; set; }

        [StringLength ( 50 )]
        public string AddressCity { get; set; }

        [StringLength ( 50 )]
        public string AddressCountry { get; set; }
        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }

        [JsonIgnore]
        public ICollection<Warehouse> Warehouses { get; set; }
       
    }
}
