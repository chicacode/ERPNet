using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebMySQL.Models
{
    public class Person
    {
        public Person ( ) { }
        [Key]
        public int PersonId { get; set; }

        [Required]
        [StringLength ( 100 )]
        public string Name { get; set; }
        public string LastName { get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
        public Address Address { get; set; }
    }
}
