using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RookieShop.Shared
{
    public class ProductDto
    {
        public string id { get; set; }
        public string imageUri { get; set; }
        //[Required]
        public string name { get; set; }
        //[Required]
        public string description { get; set; }
        //[Required]
        public int amount { get; set; }
        //[Required]
        public float price { get; set; }
        //[Required]
        public string categoryid { get; set; }
        //public virtual Category category { get; set; }
        public bool isDeleted { get; set; }

        public IFormFile image { get; set; }
        public List<RatingDto> ratings { get; set; } = new List<RatingDto>();
    }
}
