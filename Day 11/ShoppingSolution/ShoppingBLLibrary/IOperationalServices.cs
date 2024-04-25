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
        Customer CreateNewCustomer();
        Customer UpdateNewCustomer(Customer customer);
        Product UpdateProductCount(bool Behaviour, Product product);
        CartItem AddNewCartItem(Cart cart, Product product);
        double CalculateTotalValue(Cart cart);

    }
}
