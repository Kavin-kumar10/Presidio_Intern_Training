-- DDL --

CREATE DATABASE dbEmployeeTask

use dbEmployeeTask

use dbEmployeeTracker
drop database dbEmployeeTask


CREATE TABLE DEPARTMENT(
	deptname varchar(30) constraint pk_DEPARTMENT PRIMARY KEY,
	floor INT,
	phone INT,
    -- bossno int CONSTRAINT fk_EMP references EMP(empno)
)

INSERT INTO DEPARTMENT (deptname, floor, phone)
VALUES
  ('Management', 5, '34'),
  ('Books', 1, '81'),
  ('Clothes', 2, '24'),
  ('Equipment', 3, '57'),
  ('Furniture', 4, '14'),
  ('Navigation', 1, '41'),
  ('Recreation', 2, '29'),
  ('Accounting', 5, '35'),
  ('Purchasing', 5, '36'),
  ('Personnel', 5, '37'),
  ('Marketing', 5, '38');


CREATE TABLE ITEM(
	itemname varchar(30) constraint pk_ITEM PRIMARY KEY,
	itemtype varchar(20),
	itemcolor varchar(20)
)

CREATE TABLE SALES(
	salesno int identity(101,1) constraint pk_SALES PRIMARY KEY,
	saleqty int,
	itemname varchar(30) constraint fk_ITEM_SALES REFERENCES ITEM(itemname) NOT NULL,
	deptname varchar(30) constraint fk_DEPARTMENT_SALES REFERENCES DEPARTMENT(deptname) NOT NULL
)

CREATE TABLE EMP(
	empno int identity(1,1) constraint pk_EMP PRIMARY KEY,
	empname varchar(20),
	salary varchar(10),
	deptname varchar(30) CONSTRAINT fk_Department REFERENCES DEPARTMENT(deptname)
)

INSERT INTO EMP (empname, salary, deptname)
VALUES
  ('Alice', 75000, 'Management'),
  ('Ned', 45000, 'Marketing'),
  ('Andrew', 25000, 'Marketing'),
  ('Clare', 22000, 'Marketing'),
  ('Todd', 38000, 'Accounting'),
  ('Nancy', 22000, 'Accounting'),
  ('Brier', 43000, 'Purchasing'),
  ('Sarah', 56000, 'Purchasing'),
  ('Sophile', 35000, 'Personnel'),
  ('Sanjay', 15000, 'Navigation'),
  ('Rita', 15000, 'Books'),
  ('Gigi', 16000, 'Clothes'),
  ('Maggie', 11000, 'Clothes'),
  ('Paul', 15000, 'Equipment'),
  ('James', 15000, 'Equipment'),
  ('Pat', 15000, 'Furniture'),
  ('Mark', 15000, 'Recreation');

ALTER TABLE DEPARTMENT
ADD bossno int constraint fk_EMP FOREIGN KEY references EMP(empno);

UPDATE DEPARTMENT
SET bossno = 1 WHERE deptname = 'Management';

UPDATE DEPARTMENT
SET bossno =
	CASE
	WHEN deptname IN ('Management') THEN 1
	WHEN deptname IN ('Marketing') THEN 2
	WHEN deptname IN ('Books','Clothes','Recreation') THEN 4
	WHEN deptname IN ('Equipment','Furniture','Navigation') THEN 3
	WHEN deptname IN ('Accounting') THEN 5
	WHEN deptname IN ('Purchasing') THEN 7
	WHEN deptname IN ('Personnel') THEN 9
	END;

ALTER TABLE EMP
ADD bossno INT,
CONSTRAINT fk_EMP_Manager FOREIGN KEY (bossno) REFERENCES EMP(empno);

UPDATE EMP
SET bossno =
  CASE
    WHEN empname IN ('Alice') THEN NULL
    WHEN empname IN ('Ned', 'Todd', 'Brier', 'Sophile') THEN 1
    WHEN empname IN ('Andrew', 'Clare') THEN 2
    WHEN empname IN ('Rita', 'Gigi', 'Maggie') THEN 4
    WHEN empname IN ('Paul', 'James', 'Mark', 'Pat','Sanjay') THEN 3
	WHEN empname IN ('Nancy') THEN 5
	WHEN empname IN ('Sarah') THEN 7
  END;
 
INSERT INTO ITEM (itemname, itemtype, itemcolor)
VALUES
  ('Pocket Knife-Nile', 'E', 'Brown'),
  ('Pocket Knife-Avon', 'E', 'Brown'),
  ('Compass', 'N', NULL), 
  ('Geo positioning system', 'N', NULL), 
  ('Elephant Polo stick', 'R', 'Bamboo'),
  ('Camel Saddle', 'R', 'Brown'),
  ('Sextant', 'N', NULL), 
  ('Map Measure', 'N', NULL), 
  ('Boots-snake proof', 'C', 'Green'),
  ('Pith Helmet', 'C', 'Khaki'),
  ('Hat-polar Explorer', 'C', 'White'),
  ('Exploring in 10 Easy Lessons', 'B', NULL), 
  ('Hammock', 'F', 'Khaki'),
  ('How to win Foreign Friends', 'B', NULL),
  ('Map case', 'E', 'Brown'),
  ('Safari Chair', 'F', 'Khaki'),
  ('Safari cooking kit', 'F', 'Khaki'),
  ('Stetson', 'C', 'Black'),
  ('Tent - 2 person', 'F', 'Khaki'),
  ('Tent -8 person', 'F', 'Khaki');

-- To Handle in Sales
INSERT INTO DEPARTMENT
VALUES ('',1,0,1);

INSERT INTO SALES (Saleqty, itemname, Deptname)
VALUES
    (2,'Boots-snake proof','Clothes'),
    (1, 'Pith Helmet', 'Clothes'),
    (1, 'Sextant', 'Navigation'),
    (3, 'Hat-polar Explorer', 'Clothes'),
    (5, 'Pith Helmet', 'Equipment'),
    (2, 'Pocket Knife-Nile', 'Clothes'),
    (3, 'Pocket Knife-Nile', 'Recreation'),
    (1, 'Compass', 'Navigation'),
    (2, 'Geo positioning system', 'Navigation'),
    (5, 'Map Measure', 'Navigation'),
    (1, 'Geo positioning system', 'Books'),
    (1, 'Sextant', 'Books'),
    (3, 'Pocket Knife-Nile', 'Books'),
    (1, 'Pocket Knife-Nile', 'Navigation'),
    (1, 'Pocket Knife-Nile', 'Equipment'),
    (1, 'Sextant', 'Clothes'),
    (1, '', 'Equipment'),
    (1, '', 'Recreation'),
    (1, '', 'Furniture'),
    (1, 'Pocket Knife-Nile', ''),
    (1, 'Exploring in 10 easy lessons', 'Books'),
    (1, 'How to win foreign friends', ''), 
    (1, 'Compass', ''), 
    (1, 'Pith Helmet', ''), 
    (1, 'Elephant Polo stick', 'Recreation'),
    (1, 'Camel Saddle', 'Recreation');
  


SELECT * FROM EMP
SELECT * FROM DEPARTMENT
SELECT * FROM ITEM
SELECT * FROM SALES

