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
    public class AppointmentBLTest
    {
        IRepository<int, Appointment> _apppointmentrepository;
        IAppointmentService _Appointmentservices;

        [SetUp]
        public void Setup()
        {
            _apppointmentrepository = new AppointmentRepository();
            Appointment Appointment = new Appointment() {DoctorId = 1, DiseaseName = "Anemia", PatientId = 123, AppointmentDate = new DateTime(10, 11, 2000), Status = "Scheduled" };
            _apppointmentrepository.Add(Appointment);
            _Appointmentservices = new AppointmentBL(_apppointmentrepository);
        }

        //AddAppointment

        [Test]
        public void AddAppointmentPass()
        {
            Appointment Appointment = new Appointment() { DoctorId = 1,DiseaseName="Anemia", PatientId = 123, AppointmentDate = new DateTime(10,11,2000),Status = "Scheduled" };
            var result = _Appointmentservices.AddAppointment(Appointment);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void AddAppointmentException()
        {
            //Arrange
            Appointment Appointment = new Appointment() { DoctorId = 1, DiseaseName = "Anemia", PatientId = 123, AppointmentDate = new DateTime(10, 11, 2000), Status = "Scheduled" };
            //Action
            var exception = Assert.Throws<DuplicateItemException>(() => _Appointmentservices.AddAppointment(Appointment));
            //Assert
            Assert.AreEqual("The Item with current Credentials is Already Found", exception.Message);
        }

        //DeleteAppointment

        [Test]
        public void DeleteAppointmentPass()
        {
            //Action
            var result = _Appointmentservices.DeleteAppointment(1);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void DeleteAppointmentException()
        {
            //Action
            var exception = Assert.Throws<ItemNotFoundException>(() => _Appointmentservices.DeleteAppointment(2));
            //Assert
            Assert.AreEqual("The Item not found, Please provide with valid credentials.", exception.Message);
        }


        //GetAppointmentByName
        [Test]
        public void GetAppointmentByNamePassTest()
        {
            //Action
            var result = _Appointmentservices.GetAppointmentByAppointmentIdAndPatientId(1,123);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void GetAppointmentByNameFailTest()
        {
            //Action
            var result = _Appointmentservices.GetAppointmentByAppointmentIdAndPatientId(1, 123);
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAppointmentByNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<ItemNotFoundException>(() => _Appointmentservices.GetAppointmentByAppointmentIdAndPatientId(1,124));
            //Assert
            Assert.AreEqual("The Item not found, Please provide with valid credentials.", exception.Message);
        }


        //UpdateAppointment
        [Test]
        public void UpdateAppointmentPass()
        {
            //Arrange
            Appointment Appointment = new Appointment() {DoctorId = 1, DiseaseName = "Anemia", PatientId = 123, AppointmentDate = new DateTime(10, 11, 2000), Status = "Scheduled" };
            //Action
            var result = _Appointmentservices.UpdateAppointment(Appointment);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void UpdateAppointmentException()
        {
            //Arrange
            Appointment Appointment = new Appointment() {DoctorId = 1, DiseaseName = "Anemia", PatientId = 123, AppointmentDate = new DateTime(10, 11, 2000), Status = "Scheduled" };
            //Action
            var exception = Assert.Throws<ItemNotFoundException>(() => _Appointmentservices.UpdateAppointment(Appointment));
            //Assert
            Assert.AreEqual("The Item not found, Please provide with valid credentials.", exception.Message);
        }




        //GetAllAppointments

        [Test]
        public void GetAllAppointmentPass()
        {
            //Action
            var result = _Appointmentservices.GetAllAppointment();
            //Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetAllAppointmentFail()
        {
            //Action
            var result = _Appointmentservices.GetAllAppointment();
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAllAppointmentsException()
        {
            //Arrange
            IAppointmentService services = new AppointmentBL(new AppointmentRepository());
            //Action
            var exception = Assert.Throws<NoItemsFoundException>(() => services.GetAllAppointment());
            //Assert
            Assert.AreEqual("No Items Found", exception.Message);

        }

        //GetAppointmentById 

        [Test]
        public void GetAppointmentByIdPassTest()
        {
            //Action
            var result = _Appointmentservices.GetAppointmentByID(1);
            //Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void GetAppointmentByIdFailTest()
        {
            //Action
            var result = _Appointmentservices.GetAppointmentByID(1);
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAppointmentByIdExceptionTest()
        {
            //Action
            var exception = Assert.Throws<ItemNotFoundException>(() => _Appointmentservices.GetAppointmentByID(2));
            //Assert
            Assert.AreEqual("The Item not found, Please provide with valid credentials.", exception.Message);
        }
    }
}
