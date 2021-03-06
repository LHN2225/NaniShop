using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Models
{
    public class Customer
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

        public virtual List<Order> orders { get; set; } = new List<Order>();
    }
}
