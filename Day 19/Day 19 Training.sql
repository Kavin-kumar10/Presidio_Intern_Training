-- UNION
-- CTE - temperory view
-- creating view




SELECT * FROM Categories
UNION
SELECT * FROM Suppliers

select CategoryID,  categoryname from Categories
union
select SupplierId,CompanyName from Suppliers

SELECT * FROM Products
SELECT * FROM [Order Details]
SELECT * FROM Categories
-- get the order id, productname and quantitysold of products that have price
-- greater than 15

SELECT OrderID, p.productname, Quantity FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
WHERE Quantity > 15;

--get the order id, productname and quantitysold of products that are from category 'dairy'
--and within the price range of 10 to 20

SELECT OrderID, p.productname, Quantity FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%';

-- UNION
select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%'
order by p.unitprice desc

--CTE -- temperory storage

with OrderDetails_CTE(OrderID,ProductName,Quantity,Price)
as
(select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')

select top 10 * from  OrderDetails_CTE order by price desc

-- Creating virtual Table 

create view vwOrderDetails
as
(select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')


select * from vwOrderDetails order by UnitPrice

--Get the first 10 records of

--The order ID, Customer name and the product name for products that are purchaced by 
--people from USA
--The order ID, Customer name and the product name for products that are ordered by people from france 
--with fright less than 20

SELECT * FROM Customers
SELECT * FROM [Order Details]
SELECT * FROM Orders
SELECT * FROM Products

with OrderDetailFranceAndUsa_CTE (OrderID,ContactName,ProductName)
AS
(SELECT od.OrderID,c.ContactName,p.ProductName FROM [Order Details] od
JOIN Orders o ON o.OrderID = od.OrderID
JOIN Customers c ON c.CustomerID = o.CustomerID
JOIN Products p ON p.ProductId = od.ProductID
WHERE c.Country = 'USA'
UNION
SELECT od.OrderID,c.ContactName,p.ProductName FROM [Order Details] od
JOIN Orders o ON o.OrderID = od.OrderID
JOIN Customers c ON c.CustomerID = o.CustomerID
JOIN Products p ON p.ProductId = od.ProductID
WHERE c.Country = 'France' AND o.Freight<20)

SELECT Top 10 * FROM OrderDetailFranceAndUsa_CTE ORDER BY OrderID desc;

CREATE VIEW vwOrderDetailFranceAndUsa
as
(SELECT od.OrderID,c.ContactName,p.ProductName FROM [Order Details] od
JOIN Orders o ON o.OrderID = od.OrderID
JOIN Customers c ON c.CustomerID = o.CustomerID
JOIN Products p ON p.ProductId = od.ProductID
WHERE c.Country = 'USA'
UNION
SELECT od.OrderID,c.ContactName,p.ProductName FROM [Order Details] od
JOIN Orders o ON o.OrderID = od.OrderID
JOIN Customers c ON c.CustomerID = o.CustomerID
JOIN Products p ON p.ProductId = od.ProductID
WHERE c.Country = 'France' AND o.Freight<20)

SELECT * FROM vwOrderDetailFranceAndUsa



USE dbEmployeeTracker

-- INDEXING


sp_help Employees

create index idxEmpEmail on Employees(email)

select * from employees where email like 'r%'

drop index idxEmpEmail on Employees

-- Procedure basics

create procedure proc_FirstProcedure
as
begin
    print 'Hello'
end

execute proc_FirstProcedure

-- with Parameter

create proc proc_GreetWithName(@cname varchar(20))
as
begin
   print 'Hello '+@cname
end

exec proc_GreetWithName 'Ramu'

-- Change the procedure 

alter proc proc_GreetWithName(@cname varchar(20),@lname varchar(20))
as
begin
   print 'Hello '+@cname+' '+@lname
end

exec proc_GreetWithName 'Ramu','Raja'

-- DML opertion using storage methods

create proc proc_AddEmployee(@ename varchar(10),@edob datetime,
@earea varchar(10), @ephone varchar(15), @eemail varchar(15))
as
begin
   insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
   values(@ename,@edob,@earea,@ephone,@eemail)
end

exec proc_AddEmployee 'Bimu','2000-09-07','HHHH','1122334455','bimu@gmail.com'

-- type casting 

Create proc proc_PrintDetails(@cname varchar(20),@cage int,@cphone varchar(15))
as
begin
   print 'Welcome '+@cname + ' and you are '+@cage +'years old, Your phone is '+@cphone
end

alter  proc proc_PrintDetails(@cname varchar(20),@cage int,@cphone varchar(15))
as
begin
   print 'Welcome '+@cname + ' and you are '+cast(@cage as varchar(3))+'years old, Your phone is '+@cphone
end

proc_PrintDetails 'Ramu',23,'8877665544'
