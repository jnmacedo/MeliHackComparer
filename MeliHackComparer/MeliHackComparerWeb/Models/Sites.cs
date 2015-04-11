using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeliSample.Models
{
    public class Sites
    {
        public string id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}