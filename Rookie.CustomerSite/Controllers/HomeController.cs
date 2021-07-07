using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rookie.CustomerSite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RookieShop.Shared;
using System.Net;

namespace Rookie.CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PrivacyAsync()
        {
            //List<Product> productList = GetAllProductAsync("api/Products").GetAwaiter().GetResult();
            MyCallingAPI<Product> myCallingAPI = new MyCallingAPI<Product>();
            Product product = myCallingAPI.GetResFrom("api/Products/RSCAPWM0002");

            //if (product == null) return View(null);
            //return View(product);

            //Product product = new Product() { id = "1" };

            //var url = CreateProductAsync(product).GetAwaiter().GetResult();

            //Product product = GetProductAsync("api/Products/1").GetAwaiter().GetResult();

            /*if (product != null)
			{
                product.name = "I am a dummy product name";
			}*/

            /*foreach (var item in productList)
			{
                if (item.id.Contains("RSCAPM")) item.categoryid = "RSCA0001";
                else if (item.id.Contains("RSCAPWM")) item.categoryid = "RSCA0002";
                else if (item.id.Contains("RSCAPBB")) item.categoryid = "RSCA0003";

            }

            foreach (var item in productList)
			{
                UpdateProductAsync(item).GetAwaiter().GetResult(); ;
            }*/

            //var statusCode = DeleteProductAsync(product.id).GetAwaiter().GetResult();

            return View();
            //return View(product);
        }


		/*static async Task RunAsync()
		{

		}*/

		static async Task<Product> GetProductAsync(string path)
		{

			HttpClient client = new HttpClient();

			client.BaseAddress = new Uri("https://localhost:44341/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));


			Product product = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				product = await response.Content.ReadAsAsync<Product>();
			}
			return product;
		}

        static async Task<List<Product>> GetAllProductAsync(string path)
        {

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44341/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            List<Product> product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<List<Product>>();
            }
            return product;
        }
        static async Task<Uri> CreateProductAsync(Product product)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44341/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/Products", product);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<Product> UpdateProductAsync(Product product)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44341/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/products/{product.id}", product);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            product = await response.Content.ReadAsAsync<Product>();
            return product;
        }

        static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44341/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.DeleteAsync(
                $"api/Products/{id}");
            return response.StatusCode;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
