SELECT * FROM titleauthor
SELECT * FROM authors
SELECT * FROM titles
SELECT * FROM publishers
SELECT * FROM sales
SELECT * FROM employee

-- 1) Print the storeid and number of orders for the store
select stor_id,COUNT(ord_num) AS 'Order count'
from sales
GROUP BY stor_id;

-- 2) print the numebr of orders for every title

SELECT title_id,COUNT(ord_num) AS 'Order in Title'
from sales group by title_id;

SELECT * from sales
SELECT * FROM titles

-- 3) print the publisher name and book name

SELECT t.title,p.pub_name FROM titles t
LEFT JOIN publishers P
ON t.pub_id = P.pub_id;


-- 4) Print the author full name for al the authors
SELECT au_fname+' '+au_lname as AuthorFullName FROM authors

-- 5) Print the price or every book with tax (price+price*12.36/100)

SELECT title,(price+price*12.36/100) AS 'Price with Tax' FROM titles

-- 6) Print the author name, title name

SELECT t.title as Title,CONCAT(a.au_fname,' ',a.au_lname) as Author 
FROM titles t
INNER JOIN titleauthor ta ON t.title_id = ta.title_id
INNER JOIN authors a ON ta.au_id = a.au_id;

-- 7) print the author name, title name and the publisher name

SELECT t.title as Title,CONCAT(a.au_fname,' ',a.au_lname) as Author , p.pub_name as Publisher
FROM titles t
INNER JOIN titleauthor ta ON t.title_id = ta.title_id
INNER JOIN authors a ON ta.au_id = a.au_id
INNER JOIN publishers p ON p.pub_id = t.pub_id;

-- 8) Print the average price of books pulished by every publicher

SELECT p.pub_name as 'Publisher Name', AVG(t.price) AS 'Average Price of Books' FROM titles t
INNER JOIN publishers p 
ON t.pub_id = p.pub_id
GROUP BY p.pub_name;

-- 9) print the books published by 'Marjorie'

SELECT t.title FROM titles t
INNER JOIN titleauthor ta ON t.title_id = ta.title_id
INNER JOIN authors a ON a.au_id = ta.au_id
WHERE a.au_fname = 'Marjorie';

-- 10) Print the order numbers of books published by 'New Moon Books'

SELECT p.pub_name, s.ord_num FROM sales s
INNER JOIN titles t ON t.title_id = s.title_id
INNER JOIN publishers p ON p.pub_id = t.pub_id
WHERE p.pub_name = 'New Moon Books';


-- 11) Print the number of orders for every publisher


SELECT p.pub_name, COUNT(s.ord_num) as 'NUMBER OF ORDERS' FROM sales s
INNER JOIN titles t ON t.title_id = s.title_id
INNER JOIN publishers p ON p.pub_id = t.pub_id
group by p.pub_name;

-- 12) print the order number , book name, quantity, price and the total price for all orders

SELECT s.ord_num,t.title,s.qty,t.price,s.qty*t.price as 'Total Price'
FROM sales s
INNER JOIN titles t ON s.title_id = t.title_id;

-- 13) print he total order quantity fro every book

SELECT t.title,SUM(s.qty) as 'Order quantity' FROM sales s
INNER JOIN titles t ON t.title_id = s.title_id
GROUP BY t.title;

-- 14) print the total ordervalue for every book

SELECT t.title,SUM(s.qty*t.price) as 'Order quantity' FROM sales s
INNER JOIN titles t ON t.title_id = s.title_id
GROUP BY t.title;


--15) print the orders that are for the books published by the publisher for which 'Paolo' works for
--Questions.txt

SELECT s.ord_num FROM sales s
INNER JOIN titles t ON t.title_id = s.title_id
INNER JOIN publishers p ON p.pub_id = t.pub_id
INNER JOIN employee e ON e.pub_id = p.pub_id
WHERE e.fname = 'Paolo';

--Displaying Questions.txt.