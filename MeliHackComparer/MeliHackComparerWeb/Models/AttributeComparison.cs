using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeliSample.Models
{
    public class AttributeComparison
    {
        public string Name { get; set; }

        public string LeftValue { get; set; }

        public string RightValue { get; set; }

        public Boolean ShowItem
        {
            get
            {
                return !(string.IsNullOrEmpty(LeftValue.Trim()) && string.IsNullOrEmpty(RightValue.Trim()));
            }
        }
    }
}