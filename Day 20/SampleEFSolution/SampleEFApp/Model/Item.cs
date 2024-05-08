using System;
using System.Collections.Generic;

namespace SampleEFApp.Model
{
    public partial class Item
    {
        public Item()
        {
            Sales = new HashSet<Sale>();
        }

        public string Itemname { get; set; } = null!;
        public string? Itemtype { get; set; }
        public string? Itemcolor { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
