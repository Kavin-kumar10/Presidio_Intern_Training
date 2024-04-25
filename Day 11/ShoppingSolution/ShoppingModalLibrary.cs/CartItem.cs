using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingModalLibrary.cs
{
    public class CartItem : IEquatable<CartItem>
    {
        public int Id { get; set; }
        public int CartId { get; set; }//Navigation property
        public int ProductId { get; set; }
        public Product Product { get; set; }//Navigation property
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public DateTime PriceExpiryDate { get; set; }

        public override string ToString()
        {
            return "Id : " +Id+
                "\nCartId : " +CartId +
                "\nProduct Id : " + ProductId +
                "\nProduct : " + Product.ToString() +
                "\nQuantity : " + Quantity +
                "\nPrice : $" + Price +
                "\nDiscount : " + Discount +
                "\n PriceExpiryDate : " + PriceExpiryDate;
        }

        public bool Equals(CartItem? other)
        {
            return this.CartId.Equals(other.CartId);
        }

        public CartItem() { }

        public CartItem(int id,int cartId, int productId, Product product, int quantity, double price, double discount, DateTime priceExpiryDate)
        {
            Id = id;
            CartId = cartId;
            ProductId = productId;
            Product = product;
            Quantity = quantity;
            Price = price;
            Discount = discount;
            PriceExpiryDate = priceExpiryDate;
        }
    }
}
