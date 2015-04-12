
using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using MeliSample.Models;


namespace MeliSample
{
	public partial class ProductDetails : GenericPage
	{
		private MeliService ms;

        public ItemObject Item
        {
            get
            {
                return (ItemObject)Session["ProductDetail"];
            }
            set
            {
                Session["ProductDetail"] = value;
            }
        }

		protected void Page_Load(object sender, EventArgs e)
		{
			ms = MeliService.GetService ();

			string product = Request ["productID"].ToString ();

			this.Item = ms.GetProduct(product);

			this.customersRepeater.DataSource = Item.pictures;

			this.customersRepeater.DataBind();

		}
	
		public string TransformCurrency(string currency_id)
		{
			string symbol = "";
			foreach (Currency item in ms.GetCurrency()) 
			{
				if(item.id == currency_id)
					return item.symbol;
			}
			return symbol;
		}

        protected void AddToCompareList_Click(object sender, EventArgs e)
        {
            bool pertenece = Handler.IsProductInWishList(Item.id);
            if (pertenece)
            {
                Handler.RemoveProductFromWhishList(Item.id);
            }
            else
            {
                Handler.AddProductToWhishList(Item);
            }
            string category = Handler.GetCategoryLevel2(Item.id);
            List<string> categories = Handler.GetCategories();
            var b = Handler.GetProductIdList();
            var d = Handler.WhishList();
            var f = Handler.WhishList(category);
        }

	}
}

