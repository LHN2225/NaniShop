using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RookieShop.Shared;

namespace Rookie.CustomerSite.ViewModels
{
	public class ViewCategoryProduct
	{
		public CategoryDto category { get; set; }
		public List<ProductDto> productList { get; set; }
	}
}
