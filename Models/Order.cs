
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EmployeeWebMySQL.Models.enums;

namespace EmployeeWebMySQL.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }

        public OrderPriority OrderPriority { get; set; }
        public OrderState OrderState { get; set; }

        public DateTime CreationOrder { get; set; }
        public DateTime DoneByEmployeeOrder { get; set; }
        public DateTime OrderCompleted { get; set; }

        public double PriceItem { get; set; }
        public double PriceItemIva { get; set; }
        public double TotalPrice { get; set; }

        //public int AddressId { get; set; }
        //public virtual Address Address { get; set; }

        //public int CustomerId { get; set; }
        //public virtual Customer Customer { get; set; }

        //public int EmployeeId { get; set; }
        //public virtual Employee Employee { get; set; }
        public int ProductId { get; set; }

        public int ProductQuantity { get; set; }

        [JsonIgnore]
        public ICollection<Product> Products { get; set; }

    }
}
