using Microsoft.AspNetCore.Mvc;
using RookieShop.Shared;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.ViewComponents
{
	public class RatingListViewComponent : ViewComponent
	{
        public IViewComponentResult Invoke(List<RatingDto> ratingList, int totalDisplay)
        {
            dynamic target = new ExpandoObject();
            target.ratinglist = ratingList;
            target.total = totalDisplay;
            return View(target);
        }
    }
}
