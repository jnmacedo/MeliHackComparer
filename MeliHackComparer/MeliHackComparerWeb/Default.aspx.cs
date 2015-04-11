
using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using MeliSample.Models;
using System.Web.UI.WebControls;

namespace MeliSample
{
	public partial class Default : System.Web.UI.Page
	{

		private MeliService ms;


		private void populateDropDownListCategories ()
		{
			DDLcategories.Items.Clear();
			DDLcategories.DataSource = ms.GetCatergories("MLU");
			DDLcategories.DataBind();
		}

		protected override void OnLoad (EventArgs e)
		{
			base.OnLoad (e);
		
			ms = MeliService.GetService();

            if (!IsPostBack)
            {
                populateDropDownListCategories();
            }
		}

		public virtual void btnSearchClicked (object sender, EventArgs args)
		{
			ProductUserControl productUserControl = PUC;
			productUserControl.ListCurrency = ms.GetCurrency();
			productUserControl.SearchItems = ms.Search(textInput.Text, "MLU",DDLcategories.SelectedItem.Value);
            PUC.BindRepeater();
            //PUC.DataBind();
			//resultsPlaceHolder.Controls.Add(productUserControl);
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

