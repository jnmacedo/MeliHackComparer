
using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using MeliSample.Models;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Linq;

namespace MeliSample
{
    public partial class ProductUserControl : GenericUserControl
	{

        public List<Product> SearchItems
        {
            get
            {
                if (HttpContext.Current.Session["SearchItems"] == null) HttpContext.Current.Session["SearchItems"] = new List<Product>();
                return (List<Product>)HttpContext.Current.Session["SearchItems"];
            }
            set
            {
                HttpContext.Current.Session["SearchItems"] = value;
            }
        }

        public List<Currency> ListCurrency
        {
            get
            {
                if (HttpContext.Current.Session["ListCurrency"] == null) HttpContext.Current.Session["ListCurrency"] = new List<Product>();
                return (List<Currency>)HttpContext.Current.Session["ListCurrency"];
            }
            set
            {
                HttpContext.Current.Session["ListCurrency"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e) 
        {
            PreSelectedLink.InnerText = "Lista de artículos pre-seleccionados (" + Handler.WhishList(Session["Category"].ToString()).Count + ")";
            if (!IsPostBack)
                resultsDiv.Visible = false;
        }

        public void BindRepeater() {
            
            ProductSearchRepeater.DataSource = SearchItems;
            ProductSearchRepeater.DataBind();
        }

		public int Results { get; set; }

		public ProductUserControl ()
		{
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
            string[] split = ((string)e.CommandArgument).Split(',');
            string productID = split[0];
            bool in_whishlist = bool.Parse(split[1]);

            if (in_whishlist)
            {
                Handler.RemoveProductFromWhishList(productID);

                Product searchProduct = GetProductFromSearchResults(productID);
                searchProduct.in_whishlist = false;

                PreSelectedLink.InnerText = "Lista de artículos pre-seleccionados (" + Handler.WhishList(Session["Category"].ToString()).Count + ")";
            }
            else
            {
                MeliService ms = MeliService.GetService();
                ItemObject product = ms.GetProduct(productID);

                bool pertenece = Handler.IsProductInWishList(productID);
                if (!pertenece)
                {
                    Handler.AddProductToWhishList(product);
                    Product searchProduct = GetProductFromSearchResults(productID);
                    searchProduct.in_whishlist = true;
                }
            }
            PreSelectedLink.InnerText = "Lista de artículos pre-seleccionados (" + Handler.WhishList(Session["Category"].ToString()).Count + ")";
            
            BindRepeater();
        }

        protected Product GetProductFromSearchResults(string id)
        {
            return SearchItems.SingleOrDefault(p => p.id == id);

        }

        protected void ProductSearchRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            //Inside ItemCreatedEvent
            ScriptManager scriptMan = UpdateResultsSM;
            LinkButton addBtn = e.Item.FindControl("AddToListButton") as LinkButton;
            if (addBtn != null)
            {
                scriptMan.RegisterAsyncPostBackControl(addBtn);
            }
        }
	}
}

