using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModalLibrary.cs
{
    public class Product : IEquatable<Product>, IComparable<Product>
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
        public int QuantityInHand { get; set; }
        public override string ToString()
        {
            return "Id : " + Id +
                "\nName : " + Name +
                "\nPrice : $" + Price +
                "\nNos in Stock : " + QuantityInHand;
        }

        public bool Equals(Product? other)
        {
            return this.Id.Equals(other.Id);
        }

        public int CompareTo(Product? other)
        {
            if (this.Id == other.Id) return 0;
            else if (this.Id > other.Id) return 1;
            else return -1;
        }
        public Product()
        {

        }
        public Product(int id, double price, string name, int quantityInHand)
        {
            Id = id;
            Price = price;
            Name = name;
            QuantityInHand = quantityInHand;
        }
        public Product(int id, double price, string name, string? image, int quantityInHand)
        {
            Id = id;
            Price = price;
            Name = name;
            Image = image;
            QuantityInHand = quantityInHand;
        }

    }
}
