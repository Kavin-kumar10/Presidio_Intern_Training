using ShoppingModalLibrary.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface IOperationalServices
    {
        Task<Customer> CreateNewCustomer();
        Task<Customer> UpdateNewCustomer(Customer customer);
        Task<Product> UpdateProductCount(bool Behaviour, Product product);
        Task<CartItem> AddNewCartItem(Cart cart, Product product);
        Task<double> CalculateTotalValue(Cart cart);

    }
}
