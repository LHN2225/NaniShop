using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Models
{
    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }

        public virtual List<Product> products { get; set; } = new List<Product>();

    }
}
