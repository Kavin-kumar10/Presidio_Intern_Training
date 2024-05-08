using System;
using System.Collections.Generic;

namespace SampleEFApp.Model
{
    public partial class Emp
    {
        public Emp()
        {
            Departments = new HashSet<Department>();
        }

        public int Empno { get; set; }
        public string? Empname { get; set; }
        public string? Salary { get; set; }
        public string? Deptname { get; set; }

        public virtual Department? DeptnameNavigation { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
