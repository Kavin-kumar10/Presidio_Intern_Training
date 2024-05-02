-- Quantitiy > 10
SELECT * FROM Products where UnitsInStock > 10;

-- No more available 
SELECT * FROM Products where Discontinued = 1;

-- Waiting for clearance
SELECT * FROM Products where Discontinued = 1 AND UnitsInStock > 0;

--SELECT in the range of 10 to 30
SELECT * FROM Products where UnitsInStock BETWEEN 10 and 30;
-- OR
SELECT * FROM Products where UnitsInStock>=10 AND UnitsInStock<=30;

-- SELECT CALCULATION
SELECT ProductName,QuantityPerUnit, UnitPrice * UnitsinStock "Amount Worth" FROM Products WHERE CategoryId = 3;

-- LIKE STATEMENTS
SELECT * FROM Products WHERE QuantityPerUnit LIKE '%boxes%';

-- Stock of products 
SELECT SUM(UnitsInStock) as 'Stock in Catagory 3' FROM Products WHERE CategoryID = 3;

--Avreage price of products supplied by supplier 2
SELECT * from Products
SELECT AVG(UnitPrice) "average price" FROM Products WHERE SupplierID = 2;

--Worth of products in order
SELECT SUM(UnitsInStock*) FROM Products 

--Aggr by grouping
--Get the sum of products in stock for every category
select categoryId,sum(UnitsInStock) 'Stock Available' from products
group by CategoryId

--Get the average price of products supplied by every supplier
SELECT SupplierID,AVG(UnitPrice * UnitsInStock) as 'Average Price' FROM Products 
GROUP BY SupplierID;

-- No Error
select supplierID,
count(ProductName) NO_Of_Products,
sum(unitsinstock) 'Items in stock',
avg(unitprice) 'Average PRice'
from products
group by supplierID

-- Error because of ProductName one supplier id can have multiple product so its shows error but in above case we can return count
select supplierID,
ProductName,
sum(unitsinstock) 'Items in stock',
avg(unitprice) 'Average PRice'
from products
group by supplierID

-- Get the average price for every supplier for every category of product
select SupplierId, CategoryId, AVG(UnitPrice) Average_Price
from Products
group by CategoryId,SupplierID;


-- Error no Where class should be there in Group by used queries
select SupplierId, CategoryId, AVG(UnitPrice) Average_Price
from Products
WHERE AVG(UnitPrice)>15
group by CategoryId,SupplierID;

-- Instead use Having clause after the group by 
select SupplierId, CategoryId, AVG(UnitPrice) Average_Price
from Products
group by CategoryId,SupplierID
HAVING AVG(UnitPrice)>15;

-- Select category ID and Sum of Products available if 
-- the total number of products is greater than 10

SELECT CategoryID,COUNT(ProductName) as 'Count of Products' FROM Products
GROUP BY CategoryID
HAVING COUNT(ProductName)>10;

-- Order by

SELECT * FROM Products order by CategoryID,SupplierID,ProductName

SELECT * FROM Products order by ProductName;

SELECT ProductName,UnitPrice from products
WHERE UnitPrice>15
order by CategoryID;

-- Get the products sorted by the price, Fetch only those products that will 
-- be discontinued
SELECT * FROM Products 
WHERE Discontinued = 1
ORDER BY UnitPrice

-- Sort By Category Id and Fetch the sum of Unit price of products that 
-- will not be discontinued

SELECT CategoryID, SUM(UnitPrice) 'Total price' FROM Products
WHERE Discontinued != 1
GROUP BY CategoryID
ORDER BY CategoryID;

-- Select only if the category is having products total price greater than 200
SELECT CategoryId,SUM(UnitPrice) 'Total Price'
from Products
WHERE Discontinued != 1
GROUP BY CategoryID
Having SUM(UnitPrice)>150
ORDER BY 1; -- after all above process order by first col

--DESC
SELECT CategoryId,SUM(UnitPrice) 'Total Price'
from Products
WHERE Discontinued != 1
GROUP BY CategoryID
Having SUM(UnitPrice)>150
ORDER BY 1 desc;

SELECT * FROM Products ORDER BY 6;
-- OR
SELECT * FROM Products ORDER BY UnitPrice;

-- RANK
SELECT *,RANK() OVER(ORDER BY UnitPrice) 'Price Rank'
FROM Products;