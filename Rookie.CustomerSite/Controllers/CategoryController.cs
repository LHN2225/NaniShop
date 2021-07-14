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
using Microsoft.Extensions.Configuration;

namespace Rookie.CustomerSite.Controllers
{
	[Route("[controller]")]
	public class CategoryController : Controller
	{

		static HttpClient client = new HttpClient();
		static bool isInit = false;

		static IConfiguration Configuration;
		static ViewCategoryProduct viewCategoryProduct = new ViewCategoryProduct();

		public CategoryController(IConfiguration configuration)
		{
			if (!isInit)
			{
				Configuration = configuration;
				isInit = true;
				client.BaseAddress = new Uri(Configuration["BackendBaseAddress"]);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(
					new MediaTypeWithQualityHeaderValue("application/json"));
			}
		}
		/*static CategoryController()
		{
			client.BaseAddress = new Uri(Configuration["BackendBaseAddress"]);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		}*/

		// GET: CategoryController
		public ActionResult Index()
		{
			return View();
		}

		// GET: CategoryController/Details/5
		[HttpGet("{id}")]
		public ActionResult Details(string id)
		{
			viewCategoryProduct.category = GetTarget<Category>($"api/Categories/{id}").GetAwaiter().GetResult();
			if (viewCategoryProduct.category == null) return View(null);

			//viewCategoryProduct.productList = GetListTarget<Product>($"api/Categories/Details/{id}").GetAwaiter().GetResult();
			return View(viewCategoryProduct);
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
		static async Task<List<T>> GetListTarget<T>(string path) where T : class
		{
			List<T> target = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				target = await response.Content.ReadAsAsync<List<T>>();
			}
			return target;
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
