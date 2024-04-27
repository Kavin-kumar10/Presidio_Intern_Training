using ExceptionHandling;
using NUnit.Framework.Constraints;
using ShoppingDALLibrary;
using ShoppingModalLibrary.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingUnitTest
{
    public class ProductRepositoryTest
    {

        ProductRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new ProductRepository();
            _repository.Add(new Product { Id = 1, Name = "Shirt", Price = 120, QuantityInHand = 4 });
            _repository.Add(new Product { Id = 2, Name = "Pant", Price = 100, QuantityInHand = 5 });

        }

        [Test]
        public void AddNewProductPass()
        {
            //Arrange
            Product product = new Product { Id = 3, Name = "Toys", Price = 120, QuantityInHand = 4 };

            //Action
            var result = _repository.Add(product);

            //Assert
            Assert.AreEqual(3, result.Id);
        }

        [Test]
        public void AddNewProductException()
        {
            //Arrange
            Product product = new Product { Id = 1, Name = "Toys", Price = 120, QuantityInHand = 4 };

            //Action
            var exception = Assert.Throws<DuplicateItemFoundException>(()=> _repository.Add(product));

            //Assert
            Assert.IsNotNull(exception.Message);
        }

        [Test]

        public void GetAllProductsPass() { 
            
            //Action
            var result = _repository.GetAll();

            //Assert
            Assert.IsNotNull(result);
        }


        [Test]
        public void DeleteProductPass()
        {
            // Arrange
            int key = 1;
            _repository.Add(new Product { Id = 3, Name = "Toys", Price = 120, QuantityInHand = 4 });
            _repository.Add(new Product { Id = 4, Name = "Ball", Price = 50, QuantityInHand = 3 });

            // Act
            var deletedProduct = _repository.Delete(key);

            // Assert
            Assert.That(deletedProduct.Id, Is.EqualTo(key));
            Assert.That(_repository.items.Count, Is.EqualTo(3));
            Assert.That(_repository.items.All(p => p.Id != key), Is.True);
        }

        [Test]
        public void DeleteProductException()
        {
            // Arrange
            int key = 5; // Not present in sample data

            // Act
            var exception = Assert.Throws<ItemNotFoundException>(() => _repository.Delete(key));

            // Assert
            Assert.IsNotNull(exception.Message);
        }

        [Test]
        public async Task UpdateProductPass()
        {
            // Arrange
            int key = 1;
            var updatedProduct = new Product { Id = 1, Name = "Updated Shirt", Price = 150, QuantityInHand = 2 };

            // Act
            var returnedProduct = await _repository.Update(updatedProduct);

            // Assert
            Assert.That(returnedProduct, Is.Not.Null);
            Assert.That(returnedProduct.Id, Is.EqualTo(key));
            Assert.That(returnedProduct.Name, Is.EqualTo(updatedProduct.Name));
            Assert.That(returnedProduct.Price, Is.EqualTo(updatedProduct.Price));
            Assert.That(returnedProduct.QuantityInHand, Is.EqualTo(updatedProduct.QuantityInHand));
        }

        [Test]
        public void UpdateProductFail()
        {
            // Arrange
            var updatedProduct = new Product { Id = 3, Name = "Updated Shirt", Price = 150, QuantityInHand = 2 };

            // Act
            var exception = Assert.Throws<ItemNotFoundException>(() => _repository.Update(updatedProduct));

            // Assert
            Assert.That(exception.Message, Is.Not.Null); // Exception message verification depends on your implementation
        }


    }
}
