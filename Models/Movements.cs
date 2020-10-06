using ERPNet.Models;
using System;

namespace EmployeeWebMySQL.Models
{
    public class Movements : IEntity
    {
        public int Id { get; set; }
        public DateTime InOutDate { get; set; }
        public int Quantity { get; set; }
        public bool IsInput { get; set; }

        public int StorageId { get; set; }
        public Storage Storage { get; set; }
       
    }
}
