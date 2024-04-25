using ExceptionHandling;
using ShoppingDALLibrary;
using ShoppingModalLibrary.cs;

namespace ShoppingUnitTest
{
    public class CustomerRepositoryTests
    {
        CustomerRepository _customerRepository;
        private List<Customer> _customers;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new CustomerRepository();
            _customers = new List<Customer>()
            {
                new Customer { Id = 1, Name = "John Doe", Age = 30,Phone = "9876547654" },
                new Customer { Id = 2, Name = "Jane Doe", Age = 25, Phone = "9654345678" },
            };
        }


        [Test]
        public void AddCustomerToTheList()
        {
            // Arrange
            _customerRepository.items.AddRange(_customers);
            var newCustomer = new Customer { Id = 3, Name = "New Customer", Age = 40 };

            // Action
            var addedCustomer = _customerRepository.Add(newCustomer);

            // Assert
            Assert.That(_customerRepository.items.Count, Is.EqualTo(3));
            Assert.That(addedCustomer, Is.SameAs(newCustomer));
            Assert.That(_customerRepository.items.Contains(newCustomer), Is.True);
        }

        [Test]
        public void GetAllCustomerFromTheList()
        {
            // Arrange
            _customerRepository.items.AddRange(_customers);

            // Action
            var allCustomers = _customerRepository.GetAll();

            // Assert
            Assert.That(allCustomers, Is.SameAs(_customerRepository.items)); // Assuming GetAll returns the original list
        }

        [Test]
        public void DeleteCustomerFromTheList()
        {
            // Arrange
            int key = 1;
            _customerRepository.items.AddRange(_customers);

            // Action
            var deletedCustomer = _customerRepository.Delete(key);

            // Assert
            Assert.That(deletedCustomer.Id, Is.EqualTo(key));
            Assert.That(_customerRepository.items.Count, Is.EqualTo(1));
            Assert.That(_customerRepository.items.All(c => c.Id != key), Is.True);
        }

        [Test]
        public void DeleteWithIdNotPresentException()
        {
            // Arrange
            int key = 3; // Not present in sample data

            // Action
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(()=> _customerRepository.Delete(key));
            // Assert
            Assert.AreEqual("Customer with the given Id is not present", exception.Message);
        }

        [Test]
        public void GetCustomerByKey()
        {
            // Arrange
            int key = 1;
            _customerRepository.items.AddRange(_customers);

            // Act
            var customer = _customerRepository.GetByKey(key);

            // Assert
            Assert.That(customer, Is.Not.Null);
            Assert.That(customer.Id, Is.EqualTo(key));
        }

        [Test]
        public void GetCutomerByKeyException()
        {
            // Arrange
            int key = 3; // Not present in sample data

            // Act
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => _customerRepository.GetByKey(key));

            // Assert
            Assert.That(exception.Message, Is.Not.Null); // Exception message verification depends on your implementation
        }

        [Test]
        public void Update_ShouldUpdateCustomer()
        {
            // Arrange
            int key = 1;
            var updatedCustomer = new Customer { Id = 1, Name = "Updated Name", Age = 35 };
            _customerRepository.items.AddRange(_customers);

            // Act
            var returnedCustomer = _customerRepository.Update(updatedCustomer);

            // Assert
            Assert.That(returnedCustomer, Is.Not.Null);
            Assert.That(returnedCustomer.Id, Is.EqualTo(key));
            Assert.That(returnedCustomer.Name, Is.EqualTo(updatedCustomer.Name));
            Assert.That(returnedCustomer.Age, Is.EqualTo(updatedCustomer.Age));
        }

        [Test]
        public void Update_ShouldReturnNullIfCustomerNotFound()
        {
            // Arrange
            var updatedCustomer = new Customer
            {
                Id = 3,
                Name = "Updated Name",
                Age = 3
            };

            // Act
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => _customerRepository.Update(updatedCustomer));

            //Assert
            Assert.That(exception.Message, Is.Not.Null);
        }
    }
}