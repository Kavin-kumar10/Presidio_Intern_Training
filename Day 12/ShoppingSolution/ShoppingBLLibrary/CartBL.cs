using ExceptionHandling;
using ShoppingDALLibrary;
using ShoppingModalLibrary.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartBL : ICartServices
    {
        readonly IRepository<int,Cart> _cartrepository;

        public CartBL(CartRepository cartrepository)
        {
            _cartrepository = cartrepository;
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
