select * from customers where CustomerID not in (select distinct customerid from Orders)

select * from orders

select ContactName,ShipName,ShipAddress
from customers c join orders o
on c.CustomerID = o.CustomerID

select ContactName,ShipName,ShipAddress
from customers c left outer join orders o
on c.CustomerID = o.CustomerID

-- are there products which are never orderered
SELECT * FROM Products WHERE ProductID NOT IN (SELECT DISTINCT ProductID FROM Orders)
SELECT * FROM [Order Details]