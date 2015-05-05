using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kitchinv.Models
{
    public class Inventory
    {
        public Guid id { get; set; }
        public virtual ICollection<InventoryItem> items { get; set; }
        public virtual ApplicationUser owner { get; set; }
    }
}