using Microsoft.Extensions.Configuration;
using RookieShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace Rookie.CustomerSite
{
	public class MyCallingAPI<T> where T: class
	{ 
		public static HttpClient client = new HttpClient();
		//private static readonly IConfiguration Configuration;

		static MyCallingAPI()
		{
			client.BaseAddress = new Uri("http://localhost:44341/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<T>  GetResAsync(string path)
		{
			//ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			HttpClientHandler handler = new HttpClientHandler();
			handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
			handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;

			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				return await response.Content.ReadAsAsync<T>();
			}
			return default(T);
		}

		public async Task<List<T>> GetAllResAsync(string path)
		{
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				return await response.Content.ReadAsAsync<List<T>>();
			}
			return null;
		}

		public T GetResFrom(string path)
		{
			return GetResAsync(path).GetAwaiter().GetResult();
		}

		public List<T> GetAllResFrom(string path)
		{
			return GetAllResAsync(path).GetAwaiter().GetResult();
		}
	}
}
