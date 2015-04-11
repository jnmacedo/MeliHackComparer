using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeliSample.Models
{
    public class Currency
    {
        public string id { get; set; }
        public string description { get; set; }
        public string symbol { get; set; }
        public int decimal_places { get; set; }
    }
}