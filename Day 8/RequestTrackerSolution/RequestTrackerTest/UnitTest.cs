using RequestTrackerDALLibrary;
using RequestTrackerModalClasses;

namespace RequestTrackerTest
{
    public class Tests
    {
        IRepository<int, Department> repository;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
        }

        [Test]
        [TestCase(1,"EEE","Pravin")]
        [TestCase(2, "CSE", "Raju")]
        public void AddSuccessAddTest(int id,string dept,string Department_Head)
        {
            //Arrange 
            Department department = new Department() { Name = dept, Department_Head = Department_Head };
            //Action
            var result = repository.Add(department); ;
            //Assert
            Assert.AreEqual(1,result.Id);
        }
        [Test]
        public void AddFailAddTest()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", Department_Head = "kavin" };
            repository.Add(department);
            department = new Department() { Name = "IT", Department_Head = "pravin" };
            //Action
            var result = repository.Add(department);
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetAllSuccessTest()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", Department_Head = "kavin" };
            //Action
            repository.Add(department);
            var result = repository.GetAll();
            //Assert
            Assert.Greater(0, result.Count);
        }

        [Test]
        public void GetAllFailTest()
        {
            Department department = new Department();
            var result = repository.GetAll();
            Assert.IsNull(result);
        }

    }
}