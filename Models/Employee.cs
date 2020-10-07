using ERPNet.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace EmployeeWebMySQL.Models
{
    public class Employee : IEntity
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public string PositionJob { get; set; }
        public int Salary { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool isAdmin { get; set; }

        public virtual Person Person { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
        
    }
}
