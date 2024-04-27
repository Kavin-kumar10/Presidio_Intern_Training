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
    /// <summary>
    /// Seperate Solution Every Task Required Done in Single Operational File - Main FileS
    /// </summary>
    public class OperationalBL : IOperationalServices
    {
        IRepository<int, Product> _productrepository;
        IRepository<int,Cart> _cartrepository;
        IRepository<int, CartItem> _cartitemrepository;
        IRepository<int, Customer> _customerrepository;
        public OperationalBL(CustomerRepository customerrepository, CartRepository cartrepository,CartItemRepository cartItemrepository, ProductRepository productrepository) {
            _productrepository = productrepository;
            _cartrepository = cartrepository;
            _cartitemrepository = cartItemrepository;
            _customerrepository = customerrepository;
        }
        //IProductServices productServices = new ProductBL();
        //ICartServices cartServices = new CartBL();
        //ICartItemsServices cartItemsServices = new CartBL();
        //ICustomerServices customerServices = new CustomerBL();
        public async Task<Customer> CreateNewCustomer()
        {
            Customer customer = new Customer();
            await _customerrepository.Add(customer);
            Cart cart = new Cart() { Customer = customer,CustomerId = customer.Id};
            await _cartrepository.Add(cart);
            return customer;
        }

        public async Task<Customer> UpdateNewCustomer(Customer customer)
        {
            Customer findcustomer = await _customerrepository.GetByKey(customer.Id);
            if(findcustomer != null)
            {
                findcustomer = customer;
                _customerrepository.Update(findcustomer);
                return findcustomer;
            }
            throw new ItemNotFoundException();
        }

        public async Task<Product> UpdateProductCount(bool Behaviour, Product product) // true to reduce count // false to increase count
        {
            Product myproduct = await _productrepository.GetByKey(product.Id);
            Product outproduct = new Product();
            if(myproduct != null)
            {
                if(Behaviour) {
                    myproduct.QuantityInHand--;
                    outproduct = await _productrepository.Update(myproduct);
                }
                else
                {
                    myproduct.QuantityInHand++;
                    outproduct =await _productrepository.Update(myproduct);
                }
                return outproduct;
            }
            throw new ItemNotFoundException();
        }

        // Task c
        public async Task<CartItem> AddNewCartItem(Cart cart,Product product)
        {
            CartItem cartitem = new CartItem() { Product = product,ProductId = product.Id,CartId = cart.Id,Discount = 10,Price = 120,PriceExpiryDate = new DateTime(),Quantity = 12};
            Cart mycart = await _cartrepository.GetByKey(cart.Id);
            if(mycart.CartItems.Count == 5) {
                throw new MaximumQuantityExceedException();
            }
            var result = await _cartitemrepository.Add(cartitem);
            UpdateProductCount(true, product);
            return result;
        }

        // Task a,b
        public async Task<double> CalculateTotalValue(Cart cart)
        {
            double total = cart.CartItems.Select(elem=>elem.Price).Sum();
            if (total <= 100)
                return total + 100;//100 Shipping charge
            else if (cart.CartItems.Count <= 3 && cart.CartItems.Select(elem=>elem.Price).Sum() >= 1500)
            {
                return total - total * (5 / 100);
            }
            return total;
        }


    }
}
