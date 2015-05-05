using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kitchinv.Models
{
    public class Uom
    {
        public Guid id { get; set; }
        public String name { get; set; }
        public Uom parent { get; set; }
        public Double parent_conversion { get; set; }
    }
}