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
        Task<List<CartItem>> GetCartItemsByCartId(int id);
        Task<Cart> GetCartById(int id);
        Task<Cart> AddItemsToCart(int CustomerId, CartItem cartitem);
        Task<Cart> UpdateCart(Cart cart);
        Task<Cart> EmptyCart(Cart cart);
        Task<Cart> GetCartByCustomerId(int customerId);
        Task<Product> UpdateProductCount(bool Behaviour, Product product);
    }
}
