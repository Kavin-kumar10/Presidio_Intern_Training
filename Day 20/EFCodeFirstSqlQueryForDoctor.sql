CREATE DATABASE dbDoctorTracker
USE dbDoctorTracker

CREATE TABLE Patients (
  Id int PRIMARY KEY IDENTITY,
  Name varchar(50) NOT NULL,
  DiseaseName varchar(50),
  DateOfBirth date NOT NULL,
  Age int,
  Address varchar(100),
  MobileNumber varchar(20)
)

CREATE TABLE Doctor(
  Id int PRIMARY KEY IDENTITY,
  Name varchar(50) NOT NULL,
  Experience int,
  Age int,
  Qualification varchar(20),
  Speciality varchar(20)
)


CREATE TABLE Appointment(
	Id int PRIMARY KEY IDENTITY,
	DiseaseName varchar(50) NOT NULL,
	PatientId int,
	Status varchar(20),
	DoctorId int,
	AppointmentDate DateTime,
)

