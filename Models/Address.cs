using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeWebMySQL.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        public int AddressNumber { get; set; }
        public string AddressStreet { get; set; }

        public string AddressContactName { get; set; }

        public string AddressZipCode { get; set; }

        public string AddressCity { get; set; }

        public string AddressCountry { get; set; }

        [JsonIgnore]
        public ICollection<Person> Persons { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }

        [JsonIgnore]
        public ICollection<Warehouse> Warehouses { get; set; }
    }
}
