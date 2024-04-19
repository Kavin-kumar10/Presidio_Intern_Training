using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModalClasses
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department_Head { get; set; }
        public Department(int id, string name, string department_Head)
        {
            Id = id;
            Name = name;
            Department_Head = department_Head;
        }

        public override bool Equals(object? obj)
        {
            return this.Name.Equals((obj as Department).Name);
        }
        public override string ToString()
        {
            return Id + " " + Name + " " + Department_Head;
        }
    }
}
