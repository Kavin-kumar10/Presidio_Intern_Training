use dbEmployeeTracker

SELECT * FROM EmployeeSkill
SELECT * FROM  Employees

INSERT INTO Employees values ('pravin',25-11-1999,'FFFF','987654321','pravin25@gmail.com');

INSERT INTO EmployeeSkill values (103,4,8);

SELECT * FROM Areas


--Update

UPDATE Employees SET Phone = '8344442124'
WHERE id = 101;

UPDATE Employees SET Phone = '8344412228'
WHERE id = 103;

UPDATE EmployeeSkill SET SkillLevel = case
					 when SkillLevel = 7 then 5
					 when SkillLevel = 8 then 4
					 else SkillLevel
					 end;

--Delete

DELETE FROM EmployeeSkill WHERE SkillLevel = 5;