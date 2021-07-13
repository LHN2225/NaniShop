using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Models
{
    public class Order
    {
        public string id { get; set; }
        public virtual Customer customer { get; set; }
        public float total { get; set; }

        public virtual List<OrderDetail> orderDetails { get; set; } = new List<OrderDetail>();

    }
}
