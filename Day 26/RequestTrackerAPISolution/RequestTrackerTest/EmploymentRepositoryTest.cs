using Microsoft.EntityFrameworkCore;
using RequestTrackerAPIApp.Context;
using RequestTrackerAPIApp.Interfaces;
using RequestTrackerAPIApp.Modals;
using RequestTrackerAPIApp.Repositories;
using RequestTrackerAPIApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerTest
{
    public class EmploymentRepositoryTest
    {
        RequestTrackerContext context;
        IRepository<int, Employee> employeeRepo;
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder()
                                                        .UseInMemoryDatabase("dummyDB");
            context = new RequestTrackerContext(optionsBuilder.Options);
            employeeRepo = new EmployeeRepository(context);
            employeeRepo.Add(new Employee
            {
                Id = 101,
                Name = "Test1",
                DateOfBirth = new DateTime(2002, 12, 12),
                Phone = "9988776655",
                Role = "Admin",
                Image = ""
            });

        }
        [Test]
        public void GetEmployeeTest()
        {
            //Arrange
            IEmployeeService employeeService = new EmployeeBasicService(employeeRepo);

            //Action
            var result = employeeService.GetEmployeeByPhone("9988776655");

            //Assert
            Assert.IsNotNull(result);

        }
    }
}
