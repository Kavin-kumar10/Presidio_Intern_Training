using ExceptionHandling;
using ShoppingDALLibrary;
using ShoppingModalLibrary.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartBL : ICartServices
    {
        IRepository<int, Cart> _cartrepository;
        IRepository<int, CartItem> _cartitemrepository;
        IRepository<int, Product> _productrepository;
        public CartBL(CartRepository cartrepository, CartItemRepository cartItemrepository, ProductRepository productrepository)
        {
            _productrepository = productrepository;
            _cartrepository = cartrepository;
            _cartitemrepository = cartItemrepository;
        }


        public Product UpdateProductCount(bool Behaviour, Product product) // true to reduce count // false to increase count
        {
            Product myproduct = _productrepository.GetByKey(product.Id);
            Product outproduct = new Product();
            if (myproduct != null)
            {
                if (Behaviour)
                {
                    myproduct.QuantityInHand--;
                    outproduct = _productrepository.Update(myproduct);
                }
                else
                {
                    myproduct.QuantityInHand++;
                    outproduct = _productrepository.Update(myproduct);
                }
                return outproduct;
            }
            throw new ItemNotFoundException();
        }

        // Task c
        public CartItem AddNewCartItem(Cart cart, Product product,int count)
        {
            CartItem cartitem = new CartItem() { Product = product, ProductId = product.Id, CartId = cart.Id, Discount = 10, Price = 120, PriceExpiryDate = new DateTime(), Quantity = count };
            Cart mycart = _cartrepository.GetByKey(cart.Id);
            if (mycart.CartItems.Count == 5)
            {
                throw new MaximumQuantityExceedException();
            }
            var result = _cartitemrepository.Add(cartitem);
            mycart.CartItems.Add(cartitem);
            UpdateProductCount(true, product);
            return result;
        }

        // Task a,b
        public double CalculateTotalValue(Cart cart)
        {
            double total = cart.CartItems.Select(elem => elem.Price).Sum();
            if (total <= 100)
            {
                cart.Shippingcharge = 100; //100 Shipping charge
                return total;
            }
            else if (cart.CartItems.Count <= 3 && cart.CartItems.Sum(elem => elem.Price) >= 1500)
            {
                return total - total * (5 / 100);
            }
            return total;
        }


        //Task - C
        public Cart AddItemsToCart(int CustomerId,CartItem cartitem)
        {
            Cart cart = GetCartByCustomerId(CustomerId);
            if(cart.CartItems.Count > 5)
            {
                throw new MaximumQuantityExceedException();
            }
            cart.CartItems.Add(cartitem);
            _cartrepository.Update(cart);
            if (cart != null) { return cart; }
            throw new ItemNotFoundException();
        }

        public Cart EmptyCart(Cart cart)
        {
            cart.CartItems = new List<CartItem>();
            _cartrepository.Update(cart);
            throw new NotImplementedException();
        }

        public Cart GetCartByCustomerId(int customerId)
        {
            var elem = _cartrepository.GetAll();
            foreach (var item in elem)
            {
                if (item.CustomerId == customerId) return item;
            }
            throw new ItemNotFoundException();
        }

        public Cart GetCartById(int id)
        {
            var result = _cartrepository.GetByKey(id);
            if(result != null)
            return result;

            throw new ItemNotFoundException();
        }

        public List<CartItem> GetCartItemsByCartId(int id)
        {
            var elem = _cartrepository.GetByKey(id);
            if(elem != null)
            {
                return elem.CartItems;
            }
            throw new ItemNotFoundException() ;
        }

        public Cart UpdateCart(Cart cart)
        {
            var result = _cartrepository.Update(cart);
            if (result != null) return result;
            throw new ItemNotFoundException();
        }
    }
}
