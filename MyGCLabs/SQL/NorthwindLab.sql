--SQL WITH NORTHWIND
--Objectives: SQL Statements

--Task: Practice writing SQL statements on the Northwind database.

--What will the application do?
--Write SQL queries to do the following:

--1. Select all the rows from the "Customers" table. 
SELECT * FROM CUSTOMERS;

--2. Get distinct countries from the Customers table.
SELECT DISTINCT COUNTRY FROM CUSTOMERS;

--3. Get all the rows from the table Customers where the Customer’s ID starts with “BL”.
SELECT * FROM Customers WHERE CustomerID LIKE 'BL%';

--4. Get the first 100 records of the orders table. DISCUSS: Why would you do this? What else would you likely need to include in this query?
SELECT TOP 100 * FROM Orders;

--5. Get all customers that live in the postal codes 1010, 3012, 12209, and 05023.
.SELECT * FROM Customers WHERE PostalCode='1010' OR PostalCode='3012' OR PostalCode='12209' OR PostalCode='05023';

--6. Get all orders where the ShipRegion is not equal to NULL.
SELECT * FROM Orders WHERE ShipRegion IS NOT NULL;

--7. Get all customers ordered by the country, then by the city.
SELECT * FROM Customers ORDER BY Country, City;

--8. Add a new customer to the customers table. You can use whatever values.
INSERT INTO Customers (CustomerID, CompanyName, ContactName, Address, City, Region, PostalCode, Country, Phone, Fax) VALUES ('dgc11','Coffey Products','Doug Coffey', '123 Main St','Grove City','MW', '43123','USA','614-444-5555','123-456-7890');
SELECT * FROM Customers WHERE CustomerID LIKE 'dgc%';

--9. Update all ShipRegion to the value ‘EuroZone’ in the Orders table, where the ShipCountry is equal to France.  
UPDATE Orders SET ShipRegion = 'EuroZone' WHERE ShipCountry = 'France';
SELECT * FROM Orders WHERE ShipCountry = 'France';

--10. Delete all orders from OrderDetails that have quantity of 1. 
DELETE FROM [Order Details] WHERE Quantity = 1
SELECT * FROM [Order Details] --WHERE Quantity = 1;

--11. Find the CustomerID that placed order 10290 (orders table).
 SELECT CustomerID From Orders WHERE OrderID = 10290;

--12. Join the orders table to the customers table.
SELECT Customers.CustomerID, Customers.ContactName, Orders.OrderID, Orders.ShipCity From Customers INNER JOIN Orders on Orders.CustomerID = Customers.CustomerID;
SELECT * From Customers INNER JOIN Orders on Orders.CustomerID = Customers.CustomerID;

--13. Get employees’ firstname for all employees who report to no one.
SELECT FirstName FROM Employees WHERE ReportsTo IS NULL;

--14. Get employees’ firstname for all employees who report to Andrew.

SELECT A.FirstName AS FirstName1, B.FirstName AS FirstName2, A.ReportsTo
FROM Employees A, Employees B
WHERE B.FirstName = 'Andrew'
AND A.ReportsTo = B.EmployeeID;


-- EXTRA Challenges
--15.Calculate the average, max, and min of the quantity at the orderdetails table, grouped by the orderid. 
SELECT MAX(Quantity) AS LargestQty FROM [Order Details] GROUP BY OrderID;
SELECT MIN(Quantity) AS SmallestQty FROM [Order Details] GROUP BY OrderID;;
SELECT AVG(Quantity) AS AverageQty FROM [Order Details] GROUP BY OrderID;;

--16. Calculate the average, max, and min of the quantity at the orderdetails table.
SELECT MAX(Quantity) AS LargestQty FROM [Order Details] GROUP BY OrderID;
SELECT MIN(Quantity) AS SmallestQty FROM [Order Details] GROUP BY OrderID;;
SELECT AVG(Quantity) AS AverageQty FROM [Order Details] GROUP BY OrderID;;

--17.Find all customers living in London or Paris
SELECT * FROM Customers WHERE City='London' OR City='Paris';

--18.Do an inner join, left join, right join on orders and customers tables. 
--Inner
Select Orders.OrderID, Customers.CustomerID
From Orders
INNER JOIN Customers on Customers.CustomerID = Orders.CustomerID;

-- LEFT JOIN 
Select Orders.OrderID, Customers.CustomerID
From Orders
LEFT JOIN Customers on Customers.CustomerID = Orders.CustomerID;

-- RIGHT JOIN 
Select Orders.OrderID, Customers.CustomerID
From Orders
Right JOIN Customers on Customers.CustomerID = Orders.CustomerID;


--19.Make a list of cities where customers are coming from. The list should not have any duplicates or nulls.
--SELECT DISTINCT City FROM CUSTOMERS WHERE City IS NOT NULL;


--20.Show a sorted list of employees’ first names. 
SELECT * FROM Employees ORDER BY FirstName ASC;

--Find total for each order

SELECT *, UnitPrice * Quantity AS 'Total Cost' FROM [Order Details];