using System.Collections.Generic;

namespace RookieShop.Shared
{
    public class Product
    {
        public string id { get; set; }
        public string imageUri { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public float price { get; set; }
        public virtual Category category { get; set; }

        public List<Rating> ratings { get; set; } = new List<Rating>();
    }
}
