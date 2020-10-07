using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using EmployeeWebMySQL.Models.enums;
using ERPNet.Models;

namespace EmployeeWebMySQL.Models
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public OrderPriority OrderPriority { get; set; }
        public OrderState OrderState { get; set; }
        public DateTime CreationOrder { get; set; }
        public DateTime DoneByEmployeeOrder { get; set; }
        public DateTime OrderCompleted { get; set; }

        public int? AddressId { get; set; }
        [JsonIgnore]
        public virtual Address Address { get; set; }

        public int? CustomerId { get; set; }
        [JsonIgnore]
        public virtual Customer Customer { get; set; }

       public int? EmployeeId { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }

        public List<OrderProduct> Products { get; set; }

    }
}
