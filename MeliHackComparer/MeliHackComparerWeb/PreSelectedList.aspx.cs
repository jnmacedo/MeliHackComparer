
using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using MeliSample.Models;
using System.Linq;
using System.Web.UI.WebControls;


namespace MeliSample
{
	public partial class PreSelectedList : GenericPage
	{
        private MeliService ms;

        public List<AttributeComparison> ComparisonList
        {
            get
            {
                if (HttpContext.Current.Session["ComparisonList"] == null) HttpContext.Current.Session["ComparisonList"] = new List<AttributeComparison>();
                return (List<AttributeComparison>)HttpContext.Current.Session["ComparisonList"];
            }
            set
            {
                HttpContext.Current.Session["ComparisonList"] = value;
            }
        }

        private string Category
        {
            get
            {
                return (string)Session["Category"];
            }
        }

        public ItemObject ItemLeft
        {
            get
            {
                return (ItemObject)Session["ItemLeft"];
            }
            set
            {
                Session["ItemLeft"] = value;
            }
        }

        public ItemObject ItemRight
        {
            get
            {
                return (ItemObject)Session["ItemRight"];
            }
            set
            {
                Session["ItemRight"] = value;
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
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Category))
                {
                    Response.Redirect("/Home.aspx");
                }
                productsRepeater.DataSource =  Handler.WhishList(Category);
                productsRepeater.DataBind();

                comparison.Visible = false;
                leftImage.Visible = false;
                rightImage.Visible = false;

                List<string> attributes = Handler.GetAttributesList(Category);
                ComparisonList = new List<AttributeComparison>();

                foreach (string att in attributes)
                {
                    AttributeComparison comp = new AttributeComparison();
                    comp.Name = att;
                    comp.LeftValue = string.Empty;
                    comp.RightValue = string.Empty;
                    ComparisonList.Add(comp);
                }

                compareRepeater.Visible = false;
                compareRepeater.DataSource = ComparisonList;
                compareRepeater.DataBind();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "scriptname", "LoadEvenData()", true);

		}
	
        protected void productsRepeater_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            string[] split = ((string)e.CommandArgument).Split(',');
            string productID = split[0];
            bool left = split[1] == "izquierda";
            bool right = split[1] == "derecha";
            bool eliminar = split[1] == "eliminar";

            ItemObject product = Handler.GetItemByID(productID);
            if (product != null)
            {
            if (left)
            {
                SetReputationTermometer(true, product);
                    leftPrecio.InnerText = TransformCurrency(product.currency_id) + " " + product.price;
                Dictionary<string, string> dictionary = Handler.GetComparableAttributesDictionary(product,Category);
                if (!divThumbs.Attributes["class"].Contains("activated")) divThumbs.Attributes["class"] += " activated";
                comparison.Visible = true;
                leftImageUrl.HRef = product.permalink;
                leftImage.Src = product.pictures[0].url;
                leftImage.Visible = true;
                foreach (AttributeComparison comp in ComparisonList)
                {
                    if (dictionary.Keys.Contains(comp.Name))
                    {
                        comp.LeftValue = dictionary[comp.Name];
                    }
                }

                compareRepeater.Visible = true;
                compareRepeater.DataSource = ComparisonList.Where(a => a.ShowItem).ToList();
                compareRepeater.DataBind();
            }
            if (right)
            {
                SetReputationTermometer(false, product);
                    rightPrecio.InnerText = TransformCurrency(product.currency_id) + " " + product.price;
                Dictionary<string, string> dictionary = Handler.GetComparableAttributesDictionary(product,Category);
                if (!divThumbs.Attributes["class"].Contains("activated")) divThumbs.Attributes["class"] += " activated";
                comparison.Visible = true;
                rightImageUrl.HRef = product.permalink;
                rightImage.Src = product.pictures[0].url;
                rightImage.Visible = true;
                foreach (AttributeComparison comp in ComparisonList)
                {
                    if (dictionary.Keys.Contains(comp.Name))
                    {
                        comp.RightValue = dictionary[comp.Name];
                    }
                }

                compareRepeater.Visible = true;
                compareRepeater.DataSource = ComparisonList.Where(a => a.ShowItem).ToList(); ;
                compareRepeater.DataBind();
            }
            if (eliminar)
            {
                    Handler.RemoveProductFromWhishList(product.id);
                    productsRepeater.DataSource = Handler.WhishList(Category);
                productsRepeater.DataBind();
            }
        }
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


        private void SetReputationTermometer(bool left, ItemObject product)
        {
            if (left)
            {
                if (product == null ||
                    product.seller == null ||
                    product.seller.seller_reputation == null ||
                    product.seller.seller_reputation.level_id == null)
                {
                    if (!leftUserInfo.Attributes["class"].Contains("reputation-level-newbie")) leftUserInfo.Attributes["class"] += " reputation-level-newbie";
                    leftRep5.Attributes["class"] = "reputation-thermometer-5";
                    leftRep4.Attributes["class"] = "reputation-thermometer-4";
                    leftRep3.Attributes["class"] = "reputation-thermometer-3";
                    leftRep2.Attributes["class"] = "reputation-thermometer-2";
                    leftRep1.Attributes["class"] = "reputation-thermometer-1";
                }
                else if (product.seller.seller_reputation.level_id.ToString().StartsWith("5"))
                {
                    if (!leftRep5.Attributes["class"].Contains("selected")) leftRep5.Attributes["class"] += " selected";
                    leftUserInfo.Attributes["class"] = "col-sm-5 fleft";
                    leftRep4.Attributes["class"] = "reputation-thermometer-4";
                    leftRep3.Attributes["class"] = "reputation-thermometer-3";
                    leftRep2.Attributes["class"] = "reputation-thermometer-2";
                    leftRep1.Attributes["class"] = "reputation-thermometer-1";
                }
                else if (product.seller.seller_reputation.level_id.ToString().StartsWith("4"))
                {
                    if (!leftRep4.Attributes["class"].Contains("selected")) leftRep4.Attributes["class"] += " selected";
                    leftUserInfo.Attributes["class"] = "col-sm-5 fleft";
                    leftRep5.Attributes["class"] = "reputation-thermometer-5";
                    leftRep3.Attributes["class"] = "reputation-thermometer-3";
                    leftRep2.Attributes["class"] = "reputation-thermometer-2";
                    leftRep1.Attributes["class"] = "reputation-thermometer-1";
                }
                else if (product.seller.seller_reputation.level_id.ToString().StartsWith("3"))
                {
                    if (!leftRep3.Attributes["class"].Contains("selected")) leftRep3.Attributes["class"] += " selected";
                    leftUserInfo.Attributes["class"] = "col-sm-5 fleft";
                    leftRep4.Attributes["class"] = "reputation-thermometer-4";
                    leftRep5.Attributes["class"] = "reputation-thermometer-5";
                    leftRep2.Attributes["class"] = "reputation-thermometer-2";
                    leftRep1.Attributes["class"] = "reputation-thermometer-1";
                }
                else if (product.seller.seller_reputation.level_id.ToString().StartsWith("2"))
                {
                    if (!leftRep2.Attributes["class"].Contains("selected")) leftRep2.Attributes["class"] += " selected";
                    leftUserInfo.Attributes["class"] = "col-sm-5 fleft";
                    leftRep4.Attributes["class"] = "reputation-thermometer-4";
                    leftRep3.Attributes["class"] = "reputation-thermometer-3";
                    leftRep5.Attributes["class"] = "reputation-thermometer-5";
                    leftRep1.Attributes["class"] = "reputation-thermometer-1";
                }
                else if (product.seller.seller_reputation.level_id.ToString().StartsWith("1"))
                {
                    if (!leftRep1.Attributes["class"].Contains("selected")) leftRep1.Attributes["class"] += " selected";
                    leftUserInfo.Attributes["class"] = "col-sm-5 fleft";
                    leftRep4.Attributes["class"] = "reputation-thermometer-4";
                    leftRep3.Attributes["class"] = "reputation-thermometer-3";
                    leftRep2.Attributes["class"] = "reputation-thermometer-2";
                    leftRep5.Attributes["class"] = "reputation-thermometer-5";
                }
            }
            if (!left)
            {
                if (product == null || 
                    product.seller == null || 
                    product.seller.seller_reputation == null ||
                    product.seller.seller_reputation.level_id == null)
                {
                    if (!rightUserInfo.Attributes["class"].Contains("reputation-level-newbie")) rightUserInfo.Attributes["class"] += " reputation-level-newbie";
                    rightRep5.Attributes["class"] = "reputation-thermometer-5";
                    rightRep4.Attributes["class"] = "reputation-thermometer-4";
                    rightRep3.Attributes["class"] = "reputation-thermometer-3";
                    rightRep2.Attributes["class"] = "reputation-thermometer-2";
                    rightRep1.Attributes["class"] = "reputation-thermometer-1";
                }
                else if (product.seller.seller_reputation.level_id.ToString().StartsWith("5"))
                {
                    if (!rightRep5.Attributes["class"].Contains("selected")) rightRep5.Attributes["class"] += " selected";
                    rightUserInfo.Attributes["class"] = "col-sm-5 fleft";
                    rightRep4.Attributes["class"] = "reputation-thermometer-4";
                    rightRep3.Attributes["class"] = "reputation-thermometer-3";
                    rightRep2.Attributes["class"] = "reputation-thermometer-2";
                    rightRep1.Attributes["class"] = "reputation-thermometer-1";
                }
                else if (product.seller.seller_reputation.level_id.ToString().StartsWith("4"))
                {
                    if (!rightRep4.Attributes["class"].Contains("selected")) rightRep4.Attributes["class"] += " selected";
                    rightUserInfo.Attributes["class"] = "col-sm-5 fleft";
                    rightRep5.Attributes["class"] = "reputation-thermometer-5";
                    rightRep3.Attributes["class"] = "reputation-thermometer-3";
                    rightRep2.Attributes["class"] = "reputation-thermometer-2";
                    rightRep1.Attributes["class"] = "reputation-thermometer-1";
                }
                else if (product.seller.seller_reputation.level_id.ToString().StartsWith("3"))
                {
                    if (!rightRep3.Attributes["class"].Contains("selected")) rightRep3.Attributes["class"] += " selected";
                    rightUserInfo.Attributes["class"] = "col-sm-5 fleft";
                    rightRep4.Attributes["class"] = "reputation-thermometer-4";
                    rightRep5.Attributes["class"] = "reputation-thermometer-5";
                    rightRep2.Attributes["class"] = "reputation-thermometer-2";
                    rightRep1.Attributes["class"] = "reputation-thermometer-1";
                }
                else if (product.seller.seller_reputation.level_id.ToString().StartsWith("2"))
                {
                    if (!rightRep2.Attributes["class"].Contains("selected")) rightRep2.Attributes["class"] += " selected";
                    rightUserInfo.Attributes["class"] = "col-sm-5 fleft";
                    rightRep4.Attributes["class"] = "reputation-thermometer-4";
                    rightRep3.Attributes["class"] = "reputation-thermometer-3";
                    rightRep5.Attributes["class"] = "reputation-thermometer-5";
                    rightRep1.Attributes["class"] = "reputation-thermometer-1";
                }
                else if (product.seller.seller_reputation.level_id.ToString().StartsWith("1"))
                {
                    if (!rightRep1.Attributes["class"].Contains("selected")) rightRep1.Attributes["class"] += " selected";
                    rightUserInfo.Attributes["class"] = "col-sm-5 fleft";
                    rightRep4.Attributes["class"] = "reputation-thermometer-4";
                    rightRep3.Attributes["class"] = "reputation-thermometer-3";
                    rightRep2.Attributes["class"] = "reputation-thermometer-2";
                    rightRep5.Attributes["class"] = "reputation-thermometer-5";
                }
            }
        }

        protected void productsRepeater_ItemCreated(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            //Inside ItemCreatedEvent
            ScriptManager scriptMan = ScriptManager.GetCurrent(this);
            LinkButton leftBtn = e.Item.FindControl("LeftButton") as LinkButton;
            LinkButton rightBtn = e.Item.FindControl("RightButton") as LinkButton;
            LinkButton deleteBtn = e.Item.FindControl("DeleteButton") as LinkButton;
            if (leftBtn != null)
            {
                scriptMan.RegisterAsyncPostBackControl(leftBtn);
            }
            if (rightBtn != null)
            {
                scriptMan.RegisterAsyncPostBackControl(rightBtn);
            }
            if (deleteBtn != null)
            {
                scriptMan.RegisterAsyncPostBackControl(deleteBtn);
            }
        }


	}
}

