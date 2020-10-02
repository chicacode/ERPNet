using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeWebMySQL.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int PersonId { get; set; }
        public string PositionJob { get; set; }
        public int Salary { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual Person Person { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
    }
}
