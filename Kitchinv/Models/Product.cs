using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kitchinv.Models
{
    public class Product
    {
        public Guid id { get; set; }
        public String name { get; set; }
        public String upc { get; set; }
    }
}