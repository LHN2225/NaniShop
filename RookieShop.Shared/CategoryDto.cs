using System.Collections.Generic;

namespace RookieShop.Shared
{
    public class CategoryDto
    {
        public string id { get; set; }
        public string name { get; set; }

        public List<ProductDto> products { get; set; } = new List<ProductDto>();

    }
}
