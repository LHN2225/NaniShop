using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Models
{
    public class Rating
    {
        public string id { get; set; }
        public string username { get; set; }
        public int ratingPoint { get; set; }
        public string Productid { get; set; }
        public DateTime localDate { get; set; }
        public string message { get; set; }

        public bool isDeleted { get; set; } = false;
        //public virtual Product Product { get; set; }

    }
}
