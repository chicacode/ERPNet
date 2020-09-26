using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeWebMySQL.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PositionJob { get; set; }
        public int Salary { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
    }
}
