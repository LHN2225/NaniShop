using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Models
{
    public class Rating
    {
        public string id { get; set; }
        public string username { get; set; }
        public int ratingPoint { get; set; }

        public virtual Product Product { get; set; }

    }
}
