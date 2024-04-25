using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingModalLibrary.cs
{
    public class Customer : IEquatable<Customer>, IComparable<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Phone { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return "Id : " + Id +
                "\nName : " + Name +
                "\nAge : $" + Age;
        }

        public bool Equals(Customer? other)
        {
            return this.Id.Equals(other.Id);
        }

        public int CompareTo(Customer? other)
        {
            if (this.Age == other.Age) return 0;
            else if (this.Age > other.Age) return 1;
            else return -1;
        }

        public Customer()
        {

        }

        public Customer(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }
    }

}
