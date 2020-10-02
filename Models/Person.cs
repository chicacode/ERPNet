using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebMySQL.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required]
        [StringLength ( 100 )]
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
