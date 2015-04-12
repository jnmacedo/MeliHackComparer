using MeliSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MeliSample
{
    public partial class GenericUserControl : UserControl
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