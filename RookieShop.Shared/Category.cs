using System.Collections.Generic;

namespace RookieShop.Shared
{
    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }

        public List<Product> products { get; set; } = new List<Product>();

    }
}
