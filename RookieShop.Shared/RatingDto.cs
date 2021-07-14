using System;

namespace RookieShop.Shared
{
    public class RatingDto
    {
        public string id { get; set; }
        public string username { get; set; }
        public int ratingPoint { get; set; }
        public string Productid { get; set; }
        public DateTime localDate { get; set; }

        //public virtual ProductDto Product { get; set; }

    }
}
