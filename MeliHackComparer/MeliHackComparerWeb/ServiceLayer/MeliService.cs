using System;
using RestSharp;
using System.Collections.Generic;
using MercadoLibre.SDK;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MeliSample.Models;

namespace MeliSample
{
	public class MeliService
	{
		public Meli service { get; set; }

		private static MeliService meliService;

		public static MeliService GetService ()
		{
			if (meliService == null) 
			{
				meliService = new MeliService();
			}
			return meliService;
		}

		private MeliService ()
		{
            service = new Meli(454439264044701, "api_key");
		}

		public List<Sites> GetSites ()
		{
			IRestResponse results = service.Get ("sites");
			return JsonConvert.DeserializeObject<List<Sites>>(results.Content);
		}

		public List<Categories> GetCatergories (string site)
		{
			string resource = "sites/" + site + "/categories";
			IRestResponse results = service.Get (resource);
			return JsonConvert.DeserializeObject<List<Categories>>(results.Content);
		}

		public ItemObject GetProduct (string product)
		{
			string resource = "/items/" + product;
			IRestResponse result = service.Get(resource);
			return JsonConvert.DeserializeObject<ItemObject>(result.Content);
		}

		public List<Currency> GetCurrency ()
		{
			string resource = "currencies";
			IRestResponse results = service.Get (resource);
			return JsonConvert.DeserializeObject<List<Currency>>(results.Content);
		}

		public UserObject GetUserInfo ()
		{
			IRestResponse results = service.Get("users/me?access_token=" + service.AccessToken );
			return JsonConvert.DeserializeObject<UserObject>(results.Content);
		}

		public List<Product> Search(string toSearch, string site ="MLA", string cat = "")
		{
			string resource = "sites/" + site + "/search?category=" + cat + "&q= " + toSearch.Trim(); 
			IRestResponse result = service.Get(resource);
			return JsonConvert.DeserializeObject<List<Product>>(JObject.Parse(result.Content)["results"].ToString());
		}

		public string Authorize ()
		{
			return service.GetAuthUrl("http://127.0.0.1:8080/Response.aspx");
		}

		public void Authenticate (string code)
		{
			string url = "http://127.0.0.1:8080/Response.aspx";
			service.Authorize(code, url);
		}
	}
	
}

