using System;
using System.Collections.Generic;

namespace SampleEFApp.Model
{
    public partial class Department
    {
        public Department()
        {
            Emps = new HashSet<Emp>();
            Sales = new HashSet<Sale>();
        }

        public string Deptname { get; set; } = null!;
        public string? Floor { get; set; }
        public string? Phone { get; set; }
        public int? Bossno { get; set; }

        public virtual Emp? BossnoNavigation { get; set; }
        public virtual ICollection<Emp> Emps { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
