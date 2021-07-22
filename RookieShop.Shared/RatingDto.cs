using System;
using System.ComponentModel.DataAnnotations;

namespace RookieShop.Shared
{
    public class RatingDto
    {
        public string id { get; set; }

        [Required]
        public string username { get; set; }
        [Required]
        public int ratingPoint { get; set; }
        public string Productid { get; set; }
        public DateTime localDate { get; set; }
        public string message { get; set; }
        public bool isDeleted { get; set; }


        //public virtual ProductDto Product { get; set; }

    }
}
