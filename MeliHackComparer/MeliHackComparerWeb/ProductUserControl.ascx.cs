
using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using MeliSample.Models;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace MeliSample
{
	public partial class ProductUserControl : System.Web.UI.UserControl
	{
        protected void Page_Load(object sender, EventArgs e) 
        {

        }

        public void BindRepeater() {
            
            ProductSearchRepeater.DataSource = SearchItems;
            ProductSearchRepeater.DataBind();
        }

		public List<Currency> ListCurrency { get; set; }

		public List<Product> SearchItems { get; set; }
	
		public int Results { get; set; }

		public ProductUserControl ()
		{
			SearchItems = new List<Product>();
			ListCurrency = new List<Currency>();
		}

		public string TransformDate(string date)
		{
			DateTime dt = DateTime.Parse(date);
			return dt.ToString("dd/MM/yy");
		}

		public string TransformCurrency(string id)
		{
			string symbol = "";
			foreach (Currency item in ListCurrency) {

				if(item.id == id)
					return item.symbol;
			}
			return symbol;
		}

        protected void ItemCommand(Object Sender, RepeaterCommandEventArgs e)
        {
            string productID = (string)e.CommandArgument;
            //Product GetProduct(productID);
            //Product deserializedProduct = JsonConvert.DeserializeObject<Product>(json);
        }


	}
}

