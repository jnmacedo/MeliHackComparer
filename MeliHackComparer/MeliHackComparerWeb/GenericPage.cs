using MeliSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeliSample
{
    public partial class GenericPage : System.Web.UI.Page
    {
        public WhishListHandler Handler
        {
            get
            {
                if (Session["WhishListHandler"] == null) Session["WhishListHandler"] = new WhishListHandler();
                return (WhishListHandler)Session["WhishListHandler"];
            }
        }
    }
}