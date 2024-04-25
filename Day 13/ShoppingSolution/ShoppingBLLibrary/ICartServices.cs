using ShoppingModalLibrary.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface ICartServices
    {
        List<CartItem> GetCartItemsByCartId(int id);
        Cart GetCartById(int id);
        Cart AddItemsToCart(int CustomerId, CartItem cartitem);
        Cart UpdateCart(Cart cart);
        Cart EmptyCart(Cart cart);
        Cart GetCartByCustomerId(int customerId);

    }
}
