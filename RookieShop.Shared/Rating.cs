namespace RookieShop.Shared
{
    public class Rating
    {
        public string id { get; set; }
        public string username { get; set; }
        public int ratingPoint { get; set; }

        public virtual Product Product { get; set; }

    }
}
