using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Item
    {
        public Item()
        {
            Supplydocuments = new HashSet<Supplydocument>();
        }

        public decimal Itemid { get; set; }
        public decimal Warehouseid { get; set; }
        public string Itemname { get; set; } = null!;
        public string? Itemdescription { get; set; }
        public decimal Quantity { get; set; }

        public virtual Warehouse Warehouse { get; set; } = null!;
        public virtual ICollection<Supplydocument> Supplydocuments { get; set; }
    }
}
