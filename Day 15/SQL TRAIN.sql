--Create a database
create database dbEmployeeTracker
use dbEmployeeTracker--Create a database

-- delete database
use master 
go
drop database dbEmployeeTracker

create Table Areas( Area varchar(20), Zipcode char(5));

sp_help Skills

-- CONVERT TO PRIMARY KEY

ALTER TABLE Areas
ALTER COLUMN Area varchar(20) NOT NULL;
ALTER TABLE Areas
Add Constraint pk_Areas PRIMARY KEY(Area);

DROP TABLE Areas;

Create Table Areas (Area varchar(20) constraint pk_Areas PRIMARY KEY, Zipcode char(5));

-- ALTER TABLE COLUMN

ALTER TABLE Areas
ADD areaDescription varchar(30);

-- Create tables

CREATE TABLE Skills ( Skill_id int identity(1,1) CONSTRAINT pk_Skills PRIMARY KEY,  Skill varchar(20) , SkillDescription varchar(50));

CREATE TABLE Employees
(id int identity(101,1) constraint pk_EmployeeId primary key,
name varchar(100),
DateOfBirth datetime constraint chk_DOB Check(DateOFBirth<GetDate()),
EmployeeArea varchar(20) constraint fk_Area references Areas(Area),
Phone varchar(15),
email varchar(100) not null)

-- composite key

CREATE TABLE EmployeeSkill
(Employee_id int constraint fk_skill_eid foreign key references Employees(id),
Skill int constraint fk_skill_EmpSkill foreign key references Skills(skill_id),
SkillLevel float constraint chk_skillLevel check(skilllevel>=0),
constraint pk_employee_skill primary key(Employee_id,Skill))

sp_help EmployeeSkill

-- DML --

--Insert

INSERT INTO Areas(Area,Zipcode) values('DDDD','12345');
INSERT INTO Areas(Zipcode,Area) values('56431','GGGG');
INSERT INTO Areas values('ZZZZ','91765');
INSERT INTO Areas values('YYYY','81765'),('XXXX','98766'),('WWWW','79845');


--INSERT FAILURES
INSERT INTO Areas(Area,Zipcode) values('DDDD','12345'); --primary key duplication
INSERT INTO Areas(Area,Zipcode) values('DDDD','12323425445'); --No Enough space
INSERT INTO Areas(Zipcode) values('12245'); -- primary key is mandatory


SELECT * FROM Areas

-- insert into skills which have identity - auto increment
INSERT INTO Skills(Skill,SkillDescription) values('C','Robotics');
INSERT INTO Skills values('Java','Backend tech'),('Python','Data science'),('Js','Web Development');

SELECT * FROM Skills

-- Foreign key insert

INSERT INTO Employees(name,DateOfBirth,EmployeeArea,Phone,email)
values ('kavin','2002-11-10','DDDD','9876543210','kavinkumarm@presidio.com');

-- should not provide identity values
INSERT INTO Employees(name,DateOfBirth,EmployeeArea,Phone,email)
values (123,'pravin','1999-11-25','XXXX','9776543210','pravinkumarm@gmail.com');


-- Employee skill - composite key

INSERT INTO EmployeeSkill values (101,3,7);

SELECT * FROM EmployeeSkill;