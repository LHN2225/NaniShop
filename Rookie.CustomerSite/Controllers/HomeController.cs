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
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Rookie.CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static bool isUpload { get; set; } = false;
        static public ProductDto productDto = new ProductDto();

        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "jpg")]
        public IFormFile photo { get; set; }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //List<ProductDto> productList = GetAllProductAsync("api/Products").GetAwaiter().GetResult();
            //MyCallingAPI<Product> myCallingAPI = new MyCallingAPI<Product>();
            //Product product = myCallingAPI.GetResFrom("api/Products/RSCAPWM0002");

            //if (product == null) return View(null);
            //return View(product);

            //ProductDto product = new ProductDto() { id = "1" };

            //var url = CreateProductAsync(product).GetAwaiter().GetResult();

            //Product product = GetProductAsync("api/Products/1").GetAwaiter().GetResult();

            /*if (product != null)
			{
                product.name = "I am a dummy product name";
			}*/

            /*foreach (var item in productList)
			{
				if (item.id.Contains("RSCAPM")) item.amount = 50;

			}

			foreach (var item in productList)
			{
				UpdateProductAsync(item).GetAwaiter().GetResult();
			}*/

            //var statusCode = DeleteProductAsync(product.id).GetAwaiter().GetResult();

            return View(productDto);
            //return View(product);
        }

        public IActionResult SendImage([FromForm] ProductDto productDto)
        {
            var photo = productDto.image;
            var url = CreateProductAsync(productDto).GetAwaiter().GetResult();
            return Redirect("Index");
        }   


        /*static async Task RunAsync()
		{

		}*/

        static async Task<ProductDto> GetProductAsync(string path)
		{

			HttpClient client = new HttpClient();

			client.BaseAddress = new Uri("https://localhost:44341/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));


			ProductDto product = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				product = await response.Content.ReadAsAsync<ProductDto>();
			}
			return product;
		}

        static async Task<List<ProductDto>> GetAllProductAsync(string path)
        {

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44341/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            List<ProductDto> product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<List<ProductDto>>();
            }
            return product;
        }
        static async Task<Uri> CreateProductAsync([FromForm] ProductDto product)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44341/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("multipart/form-data"));

            /* HttpResponseMessage response = await client.PostAsJsonAsync(
                 "api/Products/testUploadObject", product);*/
            /* HttpResponseMessage response = await client.PostAsync(
                  "api/Products/testUploadObject", new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)product));
             */
            var content = new MultipartFormDataContent(product.ToString());
                       
            HttpResponseMessage response = await client.PostAsync(
                 "api/Products/testUploadObject", content);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<ProductDto> UpdateProductAsync(ProductDto product)
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
            product = await response.Content.ReadAsAsync<ProductDto>();
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
