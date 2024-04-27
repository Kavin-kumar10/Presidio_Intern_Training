using ShoppingDALLibrary;
using ShoppingModalLibrary.cs;
using ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartItemBL : ICartItemsServices
    {
        readonly CartItemRepository _cartItemRepository;

        public CartItemBL(CartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<List<CartItem>> GetCartItemsByCartId(int cartId)
        {
            var result = await _cartItemRepository.GetAll();
                return result.Where(item => item.CartId == cartId)
                .ToList();
        }

        public async Task<CartItem> AddCartItem(CartItem cartItem)
        {
            if (cartItem.Quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cartItem.Quantity), "Quantity must be greater than zero.");
            }
            return await _cartItemRepository.Add(cartItem);
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            if (cartItem.Quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cartItem.Quantity), "Quantity must be greater than zero.");
            }
            _cartItemRepository.Update(cartItem);
        }

        public void RemoveCartItem(int cartItemId)
        {
            _cartItemRepository.Delete(cartItemId);
        }

        public double CalculateCartItemSubtotal(CartItem cartItem)
        {
            return cartItem.Quantity * cartItem.Price;
        }

        public double CalculateCartTotal(List<CartItem> cartItems)
        {
            return cartItems.Sum(CalculateCartItemSubtotal); // Use lambda expression for concise calculation
        }
    }
}
