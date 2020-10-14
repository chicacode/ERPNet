using ERPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Models
{
    public class OrderProduct : IEntity
    {
        public int Id { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public double PriceItem { get; set; }
        public double PriceItemIva { get; set; }
        public double TotalPrice { get; set; }
    }
}
