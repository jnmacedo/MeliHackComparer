
using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using MeliSample.Models;
using System.Web.UI.WebControls;

namespace MeliSample
{
	public partial class Default : GenericPage
	{

		private MeliService ms;

        private string Category
        {
            get
            {
                return (string)Session["Category"];
            }
        }

		protected override void OnLoad (EventArgs e)
		{
			base.OnLoad (e);

            ms = MeliService.GetService();
            string sessionSearch = (string)Session["Category"];
            if (string.IsNullOrEmpty(sessionSearch))
            {
                Response.Redirect("/Home.aspx");
            }
		}

		public virtual void btnSearchClicked (object sender, EventArgs args)
		{
            PerformSearch();
            //PUC.DataBind();
			//resultsPlaceHolder.Controls.Add(productUserControl);
		}

        private void PerformSearch()
        {
            ProductUserControl productUserControl = PUC;
            productUserControl.ListCurrency = ms.GetCurrency();
            productUserControl.SearchItems = ms.Search(textInput.Text, "MLU", Category);
            foreach (Product p in productUserControl.SearchItems)
            {
                p.in_whishlist = Handler.IsProductInWishList(p.id);
            }
            PUC.BindRepeater();
        }

		public virtual void btnAccessClicked (object sender, EventArgs args)
		{
			string redirectUrl = ms.Authorize();
			Response.Redirect(redirectUrl);
		}

		public virtual void btnLogoutClicked (object sender, EventArgs args)
		{
			Session.Abandon();
			Session.Clear();
			Response.Redirect("~/Default.aspx");
		}

	}
}

