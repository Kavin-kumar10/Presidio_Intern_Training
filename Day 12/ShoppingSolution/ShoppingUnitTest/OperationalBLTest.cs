using ShoppingDALLibrary;
using ShoppingModalLibrary.cs;
using ShoppingBLLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionHandling;

namespace ShoppingUnitTest
{
    public class OperationalBLTest
    {
        ProductRepository _productrepository;
        CartRepository _cartrepository;
        CartItemRepository _cartitemrepository;
        CustomerRepository _customerrepository;
        IOperationalServices _operation;
        [SetUp]
        public void Setup()
        {
            _productrepository = new ProductRepository();
            _cartrepository = new CartRepository();
            _cartitemrepository = new CartItemRepository();
            _customerrepository = new CustomerRepository();
            Product product = new Product() { Id = 1,Name = "Shirt",Price = 120,QuantityInHand = 10 };
            _productrepository.Add(product);
            Customer customer = new Customer() { Id = 0, Name = "kavin", Age = 21, Phone = "987654321" };
            _customerrepository.Add(customer);
            _operation = new OperationalBL(_customerrepository,_cartrepository,_cartitemrepository,_productrepository);
        }

        [Test]
        public void CreatingNewCustomerPassTest()
        {
            //Action
            var result = _operation.CreateNewCustomer();
            //Assert
            Assert.AreEqual(0,result.Id);
        }

        [Test]
        public void UpdateCustomerPassTest()
        {
            //Arrange
            Customer customer = new Customer() { Id = 0, Name = "kavin", Age = 21, Phone = "8344442124" };

            //Action
            var result = _operation.UpdateNewCustomer(customer);

            //Assert
            Assert.AreEqual(result.Phone, "8344442124");

        }

        [Test]
        public void UpdateCustomerExceptionTest()
        {
            //Arrange
            Customer customer = new Customer() { Id = 3, Name = "kavin", Age = 21, Phone = "8344442124" };

            //Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(()=>_operation.UpdateNewCustomer(customer));

            //Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);

        }


        [Test]

        public void UpdateProductCountPass()
        {
            //Arrange
            Product product = new Product() {Id = 1, Name = "PS5", Price = 120, QuantityInHand = 10 };
            //Action
            var result = _operation.UpdateProductCount(true, product);
            //Assert
            Assert.AreEqual(result.QuantityInHand, 9);

        }
        [Test]
        public void UpdateProductCountException()
        {
            //Arrange
            Product product = new Product() { Id = 10, Name = "PS5", Price = 120, QuantityInHand = 10 };
            //Action
            var exception =Assert.Throws<ItemNotFoundException>(()=> _operation.UpdateProductCount(true, product));
            //Assert
            Assert.AreEqual(exception.Message, "Item With Given Credentials is not found.");
        }

        [Test]
        public void AddNewCartItemSuccess()
        {
            // Arrange
            var cart = new Cart { Id = 10, Customer = new Customer(), CustomerId = new Customer().Id, CartItems = new List<CartItem>() };
            var product = new Product { Id = 5, Name = "Shirt", Price = 120, QuantityInHand = 12 };
            _productrepository.Add(product);
            _cartrepository.Add(cart); 

            // Act
            var result = _operation.AddNewCartItem(cart, product);

            // Assert
           Assert.AreEqual(result.Quantity,12);
        }



        [Test]
        public void CalculateTotalValueOfNoDiscount()
        {
            // Arrange
            var cart = new Cart { Id = 1, CartItems = new List<CartItem>() { new CartItem { Price = 100 }, new CartItem { Price = 50 } } };

            // Act
            var totalValue = _operation.CalculateTotalValue(cart);

            // Assert
            Assert.AreEqual(150, totalValue);
        }


        [Test]
        public void CalculateTotalValueWithShippingCharge()
        {
            // Arrange
            var cart = new Cart { Id = 1, CartItems = new List<CartItem>() { new CartItem { Price = 50 } } };

            // Act
            var totalValue = _operation.CalculateTotalValue(cart);

            // Assert
            Assert.AreEqual(150, totalValue); // 50 (item price) + 100 (shipping charge)
        }


        [Test]
        public void CalculateTotalValueWithDiscount()
        {
            // Arrange
            var cart = new Cart { Id = 1, CartItems = new List<CartItem>() { new CartItem { Price = 100 } } };

            // Act
            var totalValue = _operation.CalculateTotalValue(cart);

            // Assert
            Assert.AreEqual(200.0d, totalValue); 
        }


    }
}
