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
            //List<Product> products = GetProductAsync("http://localhost:44341/api/Products");
            //return View(products);

            /*using var client = new HttpClient();
            var result = await client.GetAsync("http://localhost:44341/api/Products");
            return View(result);*/

            /* Product product = null;
             using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri("http://localhost:51708");
                 client.DefaultRequestHeaders.Accept.Clear();
                 client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                 //GET Method  
                 HttpResponseMessage response = await client.GetAsync("http://localhost:44341/api/Products/RSCAPM0001");
                 if (response.IsSuccessStatusCode)
                 {
                     product = await response.Content.ReadAsAsync<Product>();
                 }
             }

             if (product == null) return View(0);
             return View(1);*/
            Product product = GetProductAsync("api/Products/RSCAPWM0002").GetAwaiter().GetResult();
            
            if (product == null) return View(null);
            return View(product);
        }


        static async Task RunAsync()
        {

        }

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
