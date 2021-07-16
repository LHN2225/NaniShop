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

        [Required]
        public string username { get; set; }

        [Required]
        public int ratingPoint { get; set; }
        public string Productid { get; set; }
        public DateTime localDate { get; set; }

        //public virtual Product Product { get; set; }

    }
}
