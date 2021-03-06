using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Models
{
    public class Product
    {
        public string id { get; set; }
        public string imageUri { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public float price { get; set; }
        public string categoryid { get; set; }

        public bool isDeleted { get; set; } = false;

        public DateTime createDate { get; set; }
        public DateTime modifyDate { get; set; }


        //public virtual Category category { get; set; }

        public virtual List<Rating> ratings { get; set; } = new List<Rating>();
    }
}
