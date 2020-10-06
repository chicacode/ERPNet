using ERPNet.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace EmployeeWebMySQL.Models
{
    public class Person : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength ( 100 )]
        public string Name { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public virtual Employee Employee { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }
       
    }
}
