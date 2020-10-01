using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebMySQL.Models
{
    public class Movements
    {
        [Key]
        public int MovementsId { get; set; }
        public DateTime InOutDate { get; set; }
        public int Quantity { get; set; }
        public bool IsInput { get; set; }
        public int StorageId { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
