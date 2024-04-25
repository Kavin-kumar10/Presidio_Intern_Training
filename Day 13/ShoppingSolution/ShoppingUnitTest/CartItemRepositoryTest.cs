using ExceptionHandling;
using ShoppingDALLibrary;
using ShoppingModalLibrary.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingUnitTest
{
    public class CartItemRepositoryTest
    {
        CartItemRepository _CartItemRepository;
        private List<CartItem> _CartItems;

        [SetUp]
        public void Setup()
        {
            Cart Cart1 = new Cart();
            Cart Cart2 = new Cart();
            Product product1 = new Product();
            Product product2 = new Product();
            _CartItemRepository = new CartItemRepository();
            _CartItems = new List<CartItem>()
            {
                new CartItem { Id = 1, CartId = Cart1.Id, Discount = 10,Price = 120,Product = product1,ProductId = product1.Id},
                new CartItem { Id = 2, CartId = Cart2.Id, Discount = 12,Price = 120, Product = product2,ProductId = product2.Id },
            };
        }


        [Test]
        public void AddCartItemToTheList()
        {
            // Arrange
            Customer customer = new Customer() { Id = 10}; 
            Cart Cart1 = new Cart() { Id = 4,Customer = customer,CustomerId = customer.Id };
            Product product1 = new Product() { Id = 12,Name = "Shirt",Price = 100,QuantityInHand = 20};
            _CartItemRepository.items.AddRange(_CartItems);
            var newCartItem = new CartItem { Id = 5, CartId = Cart1.Id, Discount = 20, Price = 125, Product = product1, ProductId = product1.Id };

            // Action
            var addedCartItem = _CartItemRepository.Add(newCartItem); 

            // Assert
            Assert.That(_CartItemRepository.items.Count, Is.EqualTo(3));
            Assert.That(addedCartItem, Is.SameAs(newCartItem));
            Assert.That(_CartItemRepository.items.Contains(newCartItem), Is.True);
        }

        [Test]
        public void GetAllCartItemFromTheList()
        {
            // Arrange
            _CartItemRepository.items.AddRange(_CartItems);

            // Action
            var allCartItems = _CartItemRepository.GetAll();

            // Assert
            Assert.That(allCartItems, Is.SameAs(_CartItemRepository.items)); // Assuming GetAll returns the original list
        }

        [Test]
        public void DeleteCartItemFromTheList()
        {
            // Arrange
            int key = 1;
            _CartItemRepository.items.AddRange(_CartItems);

            // Action
            var deletedCartItem = _CartItemRepository.Delete(key);

            // Assert
            Assert.That(deletedCartItem.Id, Is.EqualTo(key));
            Assert.That(_CartItemRepository.items.Count, Is.EqualTo(1));
            Assert.That(_CartItemRepository.items.All(c => c.Id != key), Is.True);
        }

        [Test]
        public void DeleteWithIdNotPresentException()
        {
            // Arrange
            int key = 3; // Not present in sample data

            // Action
            var exception = Assert.Throws<ItemNotFoundException>(() => _CartItemRepository.Delete(key));
            // Assert
            Assert.AreEqual("Item With Given Credentials is not found.", exception.Message);
        }

        [Test]
        public void GetCartItemByKey()
        {
            // Arrange
            int key = 1;
            _CartItemRepository.items.AddRange(_CartItems);

            // Act
            var CartItem = _CartItemRepository.GetByKey(key);

            // Assert
            Assert.That(CartItem, Is.Not.Null);
            Assert.That(CartItem.Id, Is.EqualTo(key));
        }

        [Test]
        public void GetCutomerByKeyException()
        {
            // Arrange
            int key = 3; // Not present in sample data

            // Act
            var exception = Assert.Throws<ItemNotFoundException>(() => _CartItemRepository.GetByKey(key));

            // Assert
            Assert.That(exception.Message, Is.Not.Null); // Exception message verification depends on your implementation
        }

        [Test]
        public void UpdateCartItemPass()
        {
            // Arrange

            int key = 1;
            Cart Cart1 = new Cart();
            Product product1 = new Product();
            var updatedCartItem = new CartItem { Id = 1, CartId = Cart1.Id, Discount = 10, Price = 120, Product = product1, ProductId = product1.Id };
            _CartItemRepository.items.AddRange(_CartItems);

            // Act
            var returnedCartItem = _CartItemRepository.Update(updatedCartItem);

            // Assert
            Assert.That(returnedCartItem, Is.Not.Null);

        }

        [Test]
        public void Update_ShouldReturnNullIfCartItemNotFound()
        {
            // Arrange
            Cart Cart1 = new Cart();
            Product product1 = new Product();
            var updatedCartItem = new CartItem { Id = 4, CartId = Cart1.Id, Discount = 10, Price = 120, Product = product1, ProductId = product1.Id };

            // Act
            var exception = Assert.Throws<ItemNotFoundException>(() => _CartItemRepository.Update(updatedCartItem));

            //Assert
            Assert.That(exception.Message, Is.Not.Null);
        }

    }
}
