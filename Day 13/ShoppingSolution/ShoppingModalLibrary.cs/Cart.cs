using System.Diagnostics;
using System.Xml.Linq;

namespace ShoppingModalLibrary.cs
{
    public class Cart : IEquatable<Cart>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Shippingcharge { get; set; }   
        public Customer Customer { get; set; }//Navigation property
        public List<CartItem> CartItems { get; set; }//Navigation property
        public override string ToString()
        {
            return "Id : " + Id +
                "\nCustomerId : " + CustomerId +
                Customer.ToString()+
                "\nList of Items : " + CartItems;
        }

        public bool Equals(Cart? other)
        {
            return this.Id.Equals(other.Id);
        }

        public Cart()
        {

        }

        public Cart(int id, int customerId,int ShippingCharge, Customer customer, List<CartItem> cartItems)
        {
            Id = id;
            CustomerId = customerId;
            Customer = customer;
            CartItems = cartItems;
            Shippingcharge = ShippingCharge;
        }
    }
}
