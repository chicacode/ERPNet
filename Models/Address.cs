using ERPNet.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace ERPNet.Models
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public int AddressNumber { get; set; }
        public string AddressStreet { get; set; }
        public string AddressContactName { get; set; }
        public string AddressZipCode { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }

        [JsonIgnore]
        public ICollection<Warehouse> Warehouses { get; set; }
       
    }
}
