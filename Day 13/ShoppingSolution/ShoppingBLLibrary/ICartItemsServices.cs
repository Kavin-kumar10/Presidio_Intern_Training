using ShoppingModalLibrary.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface ICartItemsServices
    {
        Task<List<CartItem>> GetCartItemsByCartId(int cartId);
        Task<CartItem> AddCartItem(CartItem cartItem);
        void UpdateCartItem(CartItem cartItem);
        void RemoveCartItem(int cartItemId);
        double CalculateCartItemSubtotal(CartItem cartItem);
        double CalculateCartTotal(List<CartItem> cartItems);
    }
}
