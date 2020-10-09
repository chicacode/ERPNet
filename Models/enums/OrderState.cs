using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Models
{
    public enum OrderState
    {
        PendingShipping, // 0
        PreparingShipping, // 1
        InProcess, // 2
        InDelivery, // 3
        Delivered, // 4
        Canceled // 5
    }
}
