using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Models
{
    public class OrderDetail
    {
        public string id { get; set; }
        public virtual Order order { get; set; }
        public virtual Product Product { get; set; }
        public int amount { get; set; }
        public float price { get; set; }

    }
}
