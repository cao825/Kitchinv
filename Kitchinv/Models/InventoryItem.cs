using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kitchinv.Models
{
    public class InventoryItem
    {
        public Guid id { get; set; }
        public Product product { get; set; }
        public Uom uom { get; set; }
        public Double qty { get; set; }
        public DateTime expiration { get; set; }
        public DateTime added { get; set; }
        public String notes { get; set; }
    }
}