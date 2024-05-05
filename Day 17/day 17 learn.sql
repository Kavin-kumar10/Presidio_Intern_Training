SELECT * FROM Categories

-- Sub query
SELECT * FROM Products WHERE CategoryID = 
(SELECT CategoryID FROM Categories WHERE CategoryName = 'Confections')

-- Try
SELECT * FROM Products WHERE SupplierID = 
(SELECT SupplierID FROM SUPPLIERS WHERE CompanyName= 'Tokyo Traders')

-- Select all the products that are supplied by supliers from USA -- use IN for MULTIPLE
SELECT * FROM Products WHERE SupplierID IN
(SELECT supplierID FROM Suppliers WHERE Country = 'USA');

-- GET ALL THE PRODUCTS THAT HAS 'ea' in DESCRIPTION
SELECT * FROM Products WHERE CategoryID IN
(SELECT CategoryID FROM Categories WHERE Description LIKE '%ea%');



-- GET THE product id and the quantity ordered by customers from France

SELECT ProductID, Quantity FROM [Order Details]
WHERE OrderID IN
(SELECT OrderID FROM orders
WHERE CustomerID IN
(SELECT CustomerID FROM Customers WHERE Country = 'France'))

-- GET THE PRODUCTS THAT ARE PRICED ABOVE THE AVERAGE PRICE OF ALL THE PRODUCTS
SELECT * FROM Products
WHERE UnitPrice>(SELECT AVG(UnitPrice) FROM Products)

-- select the latest order by every employee
SELECT * FROM ORDERS
where OrderDate IN
(Select distinct Max(OrderDate) from Orders group by EmployeeID)

SELECT * FROM orders o1
WHERE orderdate = 
(Select max(OrderDate) from orders o2
where o2.EmployeeID = o1.EmployeeID)
order by o1.EmployeeID;

-- select the maximum priced product in every category
SELECT * FROM Products
SELECT * FROM Categories

SELECT * FROM Products p1
where UnitPrice = (SELECT max(UnitPrice) from Products p2 where p1.CategoryID = p2.CategoryID)