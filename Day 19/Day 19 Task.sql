 use Pubs
SELECT * FROM pub_info
SELECT * FROM publishers
SELECT * FROM authors
SELECT * FROM titles
SELECT * FROM titleauthor
SELECT * FROM stores
SELECT * FROM employee
SELECT * FROM sales



-- 1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name

sp_help authors

ALTER PROC proc_booksPublished(@fname varchar(20))
as 
begin
	SELECT a.au_fname,title FROM titles t
	JOIN titleauthor ta ON ta.title_id = t.title_id
	JOIN authors a ON a.au_id = ta.au_id
	JOIN publishers p ON p.pub_id = t.pub_id
	WHERE a.au_fname = @fname;
end

exec proc_booksPublished 'Albert'

-- 2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.

CREATE PROC proc_detailsWithEmployee(@efname varchar(30))
AS
BEGIN
	SELECT t.title,t.price,s.qty,(t.price*s.qty) AS 'Total Cost' FROM employee e 
	JOIN titles t ON e.pub_id = t.pub_id
	JOIN sales s ON s.title_id = t.title_id
	WHERE e.fname = @efname
END

EXEC proc_detailsWithEmployee 'paul'
 
-- 3) Create a query that will print all names from authors and employees

SELECT (au_fname + au_lname) as 'Name of employee and author' FROM authors
UNION
SELECT (fname+lname) AS 'Name of employee and author' FROM employee
 
-- 4) Create a  query that will float the data from sales,titles, publisher and authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
-- print first 5 orders after sorting them based on the price of order
 
 SELECT TOP 5 t.title,P.pub_name,(a.au_fname+a.au_lname)as 'Author name',s.qty,(s.qty*t.price) AS 'total cost' FROM titles t
 JOIN sales s ON t.title_id = s.title_id
 JOIN publishers p ON p.pub_id = t.pub_id
 JOIN titleauthor ta ON ta.title_id = t.title_id
 JOIN authors a ON a.au_id = ta.au_id
 ORDER BY 'total cost' desc;

 
-- 5) Please learn grant and revoke