using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeWebMySQL.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        //[JsonIgnore]
        //public ICollection<Person> Persons { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
    }
}
