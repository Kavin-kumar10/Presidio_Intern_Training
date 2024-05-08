using DoctorTrackerBLLibrary;
using DoctorTrackerDALLibrary;
using DoctorTrackerException;
using DoctorTrackerDALLibrary.Model;
using System.Xml.Linq;

namespace DoctorTrackerTest
{
    public class DoctorBLTest
    {

        IRepository<int,Doctor> _doctorrepository;
        IDoctorServices _doctorservices;

        [SetUp]
        public void Setup()
        {
            _doctorrepository = new DoctorRepository();
            Doctor doctor = new Doctor() {Name = "kavin",Age = 40,Experience = 10,Speciality = "Cardio",Qualification = "MBBS" };
            _doctorrepository.Add(doctor);
            _doctorservices = new DoctorBL(_doctorrepository);
        }

        //AddDoctor

        [Test]
        [TestCase(2,"pravin",50,10,"Ortho","Pharmacy")]
        public void AddDoctorPass(int id,string name,int age,int experience,string speciality,string qualification)
        {
            Doctor doctor = new Doctor() { Id = id, Name= name, Age = age, Experience = experience,Speciality = speciality,Qualification = qualification  };
            var result = _doctorservices.AddDoctor(doctor);
            Assert.AreEqual(2, result);
        }

        [Test]
        [TestCase(1, "pravin", 50, 10, "Ortho", "Pharmacy")]
        public void AddDoctorException(int id, string name, int age, int experience, string speciality, string qualification)
        {
            //Arrange
            Doctor doctor = new Doctor() { Id = id, Name = name, Age = age, Experience = experience, Speciality = speciality, Qualification = qualification };
            //Action
            var exception = Assert.Throws<DuplicateItemException>(() => _doctorservices.AddDoctor(doctor));
            //Assert
            Assert.AreEqual("The Item with current Credentials is Already Found", exception.Message);
        }

        //DeleteDoctor

        [Test]
        public void DeleteDoctorPass()
        {
            //Action
            var result = _doctorservices.DeleteDoctor(1);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void DeleteDoctorException()
        {
            //Action
            var exception = Assert.Throws<ItemNotFoundException>(() => _doctorservices.DeleteDoctor(2));
            //Assert
            Assert.AreEqual("The Item not found, Please provide with valid credentials.", exception.Message);
        }


        //GetDoctorByName
        [Test]
        public void GetDoctorByNamePassTest()
        {
            //Action
            var result = _doctorservices.GetDoctorByName("kavin");
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void GetDoctorByNameFailTest()
        {
            //Action
            var result = _doctorservices.GetDoctorByName("kavin");
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetDoctorByNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<ItemNotFoundException>(() => _doctorservices.GetDoctorByName("Raju"));
            //Assert
            Assert.AreEqual("The Item not found, Please provide with valid credentials.", exception.Message);
        }


        //UpdateDoctor
        [Test]
        public void UpdateDoctorPass()
        {
            //Arrange
            Doctor doctor = new Doctor() { Id = 1, Name = "Rajan", Age = 44, Experience = 10, Speciality = "Cardio", Qualification = "MBBS" };
            //Action
            var result = _doctorservices.UpdateDoctor(doctor);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void UpdateDoctorException()
        {
            //Arrange
            Doctor doctor = new Doctor() { Id = 5, Name = "Rajan", Age = 44, Experience = 10, Speciality = "Cardio", Qualification = "MBBS" };
            //Action
            var exception = Assert.Throws<ItemNotFoundException>(() => _doctorservices.UpdateDoctor(doctor));
            //Assert
            Assert.AreEqual("The Item not found, Please provide with valid credentials.", exception.Message);
        }




        //GetAllDoctors

        [Test]
        public void GetAllDoctorPass()
        {
            //Action
            var result = _doctorservices.GetAllDoctors();
            //Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetAllDoctorFail()
        {
            //Action
            var result = _doctorservices.GetAllDoctors();
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAllDoctorsException()
        {
            //Arrange
            IDoctorServices services = new DoctorBL(new DoctorRepository());
            //Action
            var exception = Assert.Throws<NoItemsFoundException>(()=>services.GetAllDoctors());
            //Assert
            Assert.AreEqual("No Items Found", exception.Message);
            
        }

        //GetDoctorById 

        [Test]
        public void GetDoctorByIdPassTest()
        {
            //Action
            var result = _doctorservices.GetDoctorByID(1);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void GetDoctorByIdFailTest()
        {
            //Action
            var result = _doctorservices.GetDoctorByID(1);
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetDoctorByIdExceptionTest()
        {
            //Action
            var exception = Assert.Throws<ItemNotFoundException>(() => _doctorservices.GetDoctorByID(2));
            //Assert
            Assert.AreEqual("The Item not found, Please provide with valid credentials.",exception.Message);
        }


    }
}