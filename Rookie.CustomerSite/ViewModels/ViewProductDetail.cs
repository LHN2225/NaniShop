using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RookieShop.Shared;

namespace Rookie.CustomerSite.ViewModels
{
	public class ViewProductDetail
	{
		public int totalRatingDisplay { get; set; } = 6;
		public int limitAmount { get; set; } = 10;
		public float ratingPointAvg { get; set; } = 0;
		public int overallPointDisplay { get; set; } = 0;
		public CategoryDto category { get; set; }
		public ProductDto product { get; set; }

		public RatingDto rating { get; set; }

		public void init()
		{
			if (product.ratings.Count > 0)
			{
				for (int i = 0; i < product.ratings.Count; ++i)
				{
					ratingPointAvg += product.ratings[i].ratingPoint;
				}
				ratingPointAvg /= product.ratings.Count;

				if (ratingPointAvg < 1.5) overallPointDisplay = 1;
				else if (ratingPointAvg < 2.5) overallPointDisplay = 2;
				else if (ratingPointAvg < 3.5) overallPointDisplay = 3;
				else if (ratingPointAvg < 4.5) overallPointDisplay = 4;
				else overallPointDisplay = 5;
			}

			if (product.ratings.Count < totalRatingDisplay)
			{
				totalRatingDisplay = product.ratings.Count;
			}

			if (product.amount < 10) limitAmount = product.amount;
		}

		public void clear()
		{
			totalRatingDisplay = 6;
			limitAmount = 10;
			ratingPointAvg = 0;
			overallPointDisplay = 0;
		}
	}
}
