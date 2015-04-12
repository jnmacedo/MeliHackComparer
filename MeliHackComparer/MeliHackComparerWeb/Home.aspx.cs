using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeliSample
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAutos_Click(object sender, EventArgs e)
        {
            Session.Add("Category", "MLU1744");
            Response.Redirect("/Default.aspx");
        }

        protected void btnCasas_Click(object sender, EventArgs e)
        {
            Session.Add("Category", "MLU1468");
            Response.Redirect("/Default.aspx");
        }
    }
}