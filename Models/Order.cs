using System;
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
        public double PriceItem { get; set; }
        public double PriceItemIva { get; set; }
        public double TotalPrice { get; set; }

        //public int AddressId { get; set; }
        [JsonIgnore]
        public Address Address { get; set; }

        //public int CustomerId { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }

        //public int EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }
      
    }
}
