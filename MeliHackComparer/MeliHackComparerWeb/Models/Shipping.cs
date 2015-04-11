using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeliSample.Models
{
    public class Shipping
    {
        public object profile_id { get; set; }
        public string mode { get; set; }
        public bool local_pick_up { get; set; }
        public bool free_shipping { get; set; }
        public List<object> methods { get; set; }
        public object dimensions { get; set; }
    }
}