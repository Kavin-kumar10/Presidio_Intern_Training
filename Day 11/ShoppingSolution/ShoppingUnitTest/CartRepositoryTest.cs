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
    internal class CartRepositoryTest
    { 
        CartRepository _CartRepository;
        private List<Cart> _Carts;

        [SetUp]
        public void Setup()
        {
            Customer customer1 = new Customer();
            Customer customer2 = new Customer();
            _CartRepository = new CartRepository();
            _Carts = new List<Cart>()
            {
                new Cart { Id = 1, Customer = customer1,CustomerId = customer1.Id  },
                new Cart { Id = 2, Customer = customer2, CustomerId = customer2.Id },
            };
        }


        [Test]
        public void AddCartToTheList()
        {
            // Arrange
            _CartRepository.items.AddRange(_Carts);
            var newCart = new Cart { Id = 3, Customer = new Customer(),CustomerId = new Customer().Id };

            // Action
            var addedCart = _CartRepository.Add(newCart);

            // Assert
            Assert.That(_CartRepository.items.Count, Is.EqualTo(3));
            Assert.That(addedCart, Is.SameAs(newCart));
            Assert.That(_CartRepository.items.Contains(newCart), Is.True);
        }

        [Test]
        public void GetAllCartFromTheList()
        {
            // Arrange
            _CartRepository.items.AddRange(_Carts);

            // Action
            var allCarts = _CartRepository.GetAll();

            // Assert
            Assert.That(allCarts, Is.SameAs(_CartRepository.items)); // Assuming GetAll returns the original list
        }

        [Test]
        public void DeleteCartFromTheList()
        {
            // Arrange
            int key = 1;
            _CartRepository.items.AddRange(_Carts);

            // Action
            var deletedCart = _CartRepository.Delete(key);

            // Assert
            Assert.That(deletedCart.Id, Is.EqualTo(key));
            Assert.That(_CartRepository.items.Count, Is.EqualTo(1));
            Assert.That(_CartRepository.items.All(c => c.Id != key), Is.True);
        }

        [Test]
        public void DeleteWithIdNotPresentException()
        {
            // Arrange
            int key = 3; // Not present in sample data

            // Action
            var exception = Assert.Throws<ItemNotFoundException>(() => _CartRepository.Delete(key));
            // Assert
            Assert.AreEqual("Item With Given Credentials is not found.", exception.Message);
        }

        [Test]
        public void GetCartByKey()
        {
            // Arrange
            int key = 1;
            _CartRepository.items.AddRange(_Carts);

            // Act
            var Cart = _CartRepository.GetByKey(key);

            // Assert
            Assert.That(Cart, Is.Not.Null);
            Assert.That(Cart.Id, Is.EqualTo(key));
        }

        [Test]
        public void GetCutomerByKeyException()
        {
            // Arrange
            int key = 3; // Not present in sample data

            // Act
            var exception = Assert.Throws<ItemNotFoundException>(() => _CartRepository.GetByKey(key));

            // Assert
            Assert.That(exception.Message, Is.Not.Null); // Exception message verification depends on your implementation
        }

        [Test]
        public void UpdateCartPass()
        {
            // Arrange
            int key = 1;
            var updatedCart = new Cart { Id = 1,Customer = new Customer(),CustomerId = new Customer().Id};
            _CartRepository.items.AddRange(_Carts);

            // Act
            var returnedCart = _CartRepository.Update(updatedCart);

            // Assert
            Assert.That(returnedCart, Is.Not.Null);

        }

        [Test]
        public void Update_ShouldReturnNullIfCartNotFound()
        {
            // Arrange
            var updatedCart = new Cart
            {
                Id = 3,
                Customer = new Customer(),
                CustomerId = new Customer().Id
            };

            // Act
            var exception = Assert.Throws<ItemNotFoundException>(() => _CartRepository.Update(updatedCart));

            //Assert
            Assert.That(exception.Message, Is.Not.Null);
        }
    }
}
