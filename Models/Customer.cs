using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeWebMySQL.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public int PersonForeignKey { get; set; }
        public virtual Person Person { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
    }
}
