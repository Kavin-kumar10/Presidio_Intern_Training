using DoctorTrackerBLLibrary;
using DoctorTrackerDALLibrary;
using DoctorTrackerException;
using DoctorTrackerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorTrackerTest
{
    public class PatientBLTest
    {
        IRepository<int, Patient> _patientrepository;
        IPatientServices _patientservices;

        [SetUp]
        public void Setup()
        {
            _patientrepository = new PatientRepository();
            Patient patient = new Patient() { Name = "kavin", Age = 40, DiseaseName = "Anemia", DateOfBirth = new DateTime(2002,11,10), Address = "Theni",MobileNumber = "9876543210"};
            _patientrepository.Add(patient);
            _patientservices = new PatientBL(_patientrepository);
        }

        //AddPatient

        [Test]
        public void AddPatientPass()
        {
            Patient patient = new Patient() {Id = 2, Name = "kavin", Age = 40, DiseaseName = "Anemia", DateOfBirth = new DateTime(2002, 11, 10), Address = "Theni", MobileNumber = "987654378" };
            var result = _patientservices.AddPatient(patient);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void AddPatientException()
        {
            //Arrange
            Patient patient = new Patient() {Id = 1, Name = "kavin", Age = 40, DiseaseName = "Anemia", DateOfBirth = new DateTime(2002, 11, 10), Address = "Theni", MobileNumber = "987654378" };
            //Action
            var exception = Assert.Throws<DuplicateItemException>(() => _patientservices.AddPatient(patient));
            //Assert
            Assert.AreEqual("The Item with current Credentials is Already Found", exception.Message);
        }

        //DeletePatient

        [Test]
        public void DeletePatientPass()
        {
            //Action
            var result = _patientservices.DeletePatient(1);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void DeletePatientException()
        {
            //Action
            var exception = Assert.Throws<ItemNotFoundException>(() => _patientservices.DeletePatient(2));
            //Assert
            Assert.AreEqual("The Item not found, Please provide with valid credentials.", exception.Message);
        }


        //GetPatientByName
        [Test]
        public void GetPatientByNamePassTest()
        {
            //Action
            var result = _patientservices.GetPatientByName("kavin");
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void GetPatientByNameFailTest()
        {
            //Action
            var result = _patientservices.GetPatientByName("kavin");
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetPatientByNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<ItemNotFoundException>(() => _patientservices.GetPatientByName("Raju"));
            //Assert
            Assert.AreEqual("The Item not found, Please provide with valid credentials.", exception.Message);
        }


        //UpdatePatient
        [Test]
        public void UpdatePatientPass()
        {
            //Arrange
            Patient Patient = new Patient() {Id = 1,Name = "kavin", Age = 40, DiseaseName = "Anemia", DateOfBirth = new DateTime(2002, 11, 10), Address = "Theni" };
            //Action
            var result = _patientservices.UpdatePatient(Patient);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void UpdatePatientException()
        {
            //Arrange
            Patient Patient = new Patient() {Name = "kavin", Age = 40, DiseaseName = "Anemia", DateOfBirth = new DateTime(2002, 11, 10), Address = "Theni" };
            //Action
            var exception = Assert.Throws<ItemNotFoundException>(() => _patientservices.UpdatePatient(Patient));
            //Assert
            Assert.AreEqual("The Item not found, Please provide with valid credentials.", exception.Message);
        }




        //GetAllPatients

        [Test]
        public void GetAllPatientPass()
        {
            //Action
            var result = _patientservices.GetAllPatients();
            //Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetAllPatientFail()
        {
            //Action
            var result = _patientservices.GetAllPatients();
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAllPatientsException()
        {
            //Arrange
            IPatientServices services = new PatientBL(new PatientRepository());
            //Action
            var exception = Assert.Throws<NoItemsFoundException>(() => services.GetAllPatients());
            //Assert
            Assert.AreEqual("No Items Found", exception.Message);

        }

        //GetPatientById 

        [Test]
        public void GetPatientByIdPassTest()
        {
            //Action
            var result = _patientservices.GetPatientByID(1);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void GetPatientByIdFailTest()
        {
            //Action
            var result = _patientservices.GetPatientByID(1);
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetPatientByIdExceptionTest()
        {
            //Action
            var exception = Assert.Throws<ItemNotFoundException>(() => _patientservices.GetPatientByID(2));
            //Assert
            Assert.AreEqual("The Item not found, Please provide with valid credentials.", exception.Message);
        }


    }
}
