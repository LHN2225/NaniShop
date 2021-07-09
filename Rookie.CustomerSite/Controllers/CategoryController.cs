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
	public class CategoryController : Controller
	{

		static HttpClient client = new HttpClient();
		static ViewCategoryProduct viewCategoryProduct = new ViewCategoryProduct();

		static CategoryController()
		{
			client.BaseAddress = new Uri("https://localhost:44341/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		}

		// GET: CategoryController
		public ActionResult Index()
		{
			return View();
		}

		// GET: CategoryController/Details/5
		[HttpGet("{id}")]
		public ActionResult Details(string id)
		{
			viewCategoryProduct.category = GetCategory($"api/Categories/{id}").GetAwaiter().GetResult();
			if (viewCategoryProduct.category == null) return View(null);

			viewCategoryProduct.productList = GetProductbyCategory($"api/Categories/Details/{id}").GetAwaiter().GetResult();
			return View(viewCategoryProduct);

			return View();
		}
		static async Task<Category> GetCategory(string path)
		{
			Category category = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				category = await response.Content.ReadAsAsync<Category>();
			}
			return category;
		}
		static async Task<List<Product>> GetProductbyCategory(string path)
		{
			List<Product> products = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				products = await response.Content.ReadAsAsync<List<Product>>();
			}
			return products;
		}

		// GET: CategoryController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CategoryController/Create
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

		// GET: CategoryController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: CategoryController/Edit/5
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

		// GET: CategoryController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: CategoryController/Delete/5
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
