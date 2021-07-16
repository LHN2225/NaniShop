using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookie.CustomerSite.ViewModels;
using RookieShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Controllers
{
	[Route("[controller]")]
	public class ProductController : Controller
	{
		static HttpClient client = new HttpClient();
		static ViewProductDetail viewProductDetail = new ViewProductDetail();
		static ProductController()
		{
			client.BaseAddress = new Uri("https://localhost:44341/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		}

		static async Task<T> GetTarget<T>(string path) where T : class
		{
			T target = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				target = await response.Content.ReadAsAsync<T>();
			}
			return target;
		}


		// GET: ProductController
		public ActionResult Index()
		{
			return View();
		}

		// GET: ProductController/Details/5
		[HttpGet("{id}")]
		public ActionResult Details(string id)
		{
			viewProductDetail.product = GetTarget<ProductDto>($"api/Products/Details/{id}").GetAwaiter().GetResult();
			viewProductDetail.category = GetTarget<CategoryDto>($"api/Categories/{viewProductDetail.product.categoryid}").GetAwaiter().GetResult();
			return View(viewProductDetail);
		}

		/*[HttpPost("Details")]
		public ActionResult Details([FromForm] string ratingName, [FromForm] string ratingMessage)
		{
			return View(viewProductDetail);
		}*/

		[HttpPost("addRating")]
		public ActionResult Details([FromForm] string ratingName, [FromForm] string ratingMessage)
		{
			/*var name = Request.Form["ratingName"];
			var mess = Request.Form["ratingMessage"];*/
			var name = ratingName;
			var mess = ratingMessage;
			return Redirect($"{viewProductDetail.product.id}");
			// do something with emailAddress
		}

		// GET: ProductController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ProductController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ProductController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ProductController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ProductController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ProductController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
