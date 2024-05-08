using System;
using System.Collections.Generic;

namespace SampleEFApp.Model
{
    public partial class Sale
    {
        public int Salesno { get; set; }
        public int? Saleqty { get; set; }
        public string Itemname { get; set; } = null!;
        public string Deptname { get; set; } = null!;

        public virtual Department DeptnameNavigation { get; set; } = null!;
        public virtual Item ItemnameNavigation { get; set; } = null!;
    }
}
