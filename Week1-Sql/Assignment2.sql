-- Assignment 2
-- Date: 06/20/2024
-- Author: Vishnu Rapuru

USE AdventureWorks2019
GO

-- 1. How many products can you find in the Production.Product table?
SELECT 
    COUNT(DISTINCT p.ProductID) AS [Products Number]
FROM
    Production.Product p;

-- 2. Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT 
    COUNT(p.ProductID) AS [Products Number]
FROM
    Production.Product p
WHERE
    p.ProductSubcategoryID IS NOT NULL;

-- 3. How many Products reside in each SubCategory? Write a query to display the results with the following titles.
-- ProductSubcategoryID CountedProducts
-- -------------------- ---------------
SELECT 
    p.ProductSubcategoryID,
    COUNT(p.ProductID) AS CountedProducts
FROM
    Production.Product p
WHERE
    p.ProductSubcategoryID IS NOT NULL
GROUP BY
    p.ProductSubcategoryID;

-- 4. How many products that do not have a product subcategory.
SELECT 
    COUNT(p.ProductID) AS CountedProducts
FROM
    Production.Product p
WHERE
    p.ProductSubcategoryID IS NULL

-- 5. Write a query to list the sum of products quantity in the Production.ProductInventory table.
SELECT 
    SUM(pi.Quantity) AS [Sum of Products]
FROM
    Production.ProductInventory pi;

-- 6. Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
--               ProductID    TheSum
--               -----------  ----------
SELECT 
    pi.ProductID,
    SUM(pi.Quantity) AS TheSum
FROM
    Production.ProductInventory pi
WHERE
    pi.LocationID = 40
GROUP BY 
    pi.ProductID
HAVING
    SUM(pi.Quantity) < 100
;

-- 7. Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
--     Shelf         ProductID          TheSum
--     ----------   -----------        -----------
SELECT 
    pi.Shelf,
    pi.ProductID,
    SUM(pi.Quantity) AS TheSum
FROM
    Production.ProductInventory pi
WHERE
    pi.LocationID = 40
GROUP BY 
    pi.Shelf,
    pi.ProductID
HAVING
    SUM(pi.Quantity) < 100
;


-- 8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
SELECT 
    pi.ProductID,
    AVG(pi.Quantity) AS Average
FROM
    Production.ProductInventory pi
WHERE
    pi.LocationID = 10
GROUP BY
    ProductID
;


-- 9. Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
--     ProductID   Shelf      TheAvg
--     ----------- ---------- -----------
SELECT 
    pi.ProductID,
    pi.Shelf,
    AVG(pi.Quantity) AS TheAvg
FROM
    Production.ProductInventory pi
GROUP BY
    pi.ProductID,
    pi.Shelf
;

-- 10.  Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
--     ProductID   Shelf      TheAvg
--     ----------- ---------- -----------
SELECT 
    pi.ProductID,
    pi.Shelf,
    AVG(pi.Quantity) AS TheAvg
FROM
    Production.ProductInventory pi
WHERE
    pi.Shelf != 'N/A'
GROUP BY
    pi.ProductID,
    pi.Shelf
;


-- 11. List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
--     Color                    Class              TheCount         AvgPrice
--     --------------------    -----------         -----------     ----------
SELECT
    Color,
    Class,
    COUNT(*) AS TheCount,
    AVG(ListPrice) AS AvgPrice
FROM
    Production.Product
WHERE
    Color IS NOT NULL AND
    Class IS NOT NULL
GROUP BY
    Color,
    Class
;

-- Joins:

-- 12. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.
--     Country                        Province
--     ---------                     ----------------------
SELECT
    pc.Name AS Country,
    ps.Name AS Province
FROM 
    Person.CountryRegion pc
INNER JOIN
    Person.StateProvince ps
ON
    pc.CountryRegionCode = ps.CountryRegionCode;

-- 13. Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
--     Country                        Province
--     ---------                     ----------------------
SELECT
    pc.Name AS Country,
    ps.Name AS Province
FROM 
    Person.CountryRegion pc
INNER JOIN
    Person.StateProvince ps
ON
    pc.CountryRegionCode = ps.CountryRegionCode
WHERE
    pc.Name IN ('Germany','Canada')
ORDER BY
    pc.Name;

--  Using Northwnd Database: (Use aliases for all the Joins)
USE Northwind
GO

-- 14. List all Products that has been sold at least once in last 25 years.
SELECT
    DISTINCT
    p.ProductName
FROM
    dbo.Products p
Inner JOIN
    [Order Details] od
ON
    p.ProductID = od.ProductID
INNER JOIN
    dbo.Orders o
ON
    od.OrderID = o.OrderID
WHERE
    DATEDIFF(year, GETDATE(), o.OrderDate) <= 27;

-- 15. List top 5 locations (Zip Code) where the products sold most.
SELECT
    top 5
    o.ShipPostalCode,
    Sum(od.Quantity) AS "Products Sold"
FROM
    Orders o
INNER JOIN
    [Order Details] od
ON
    od.OrderID = o.OrderID
WHERE
    o.ShipPostalCode IS NOT NULL
GROUP BY
    o.ShipPostalCode
ORDER BY [Products Sold] DESC;

-- 16. List top 5 locations (Zip Code) where the products sold most in last 25 years.
SELECT
    top 5
    o.ShipPostalCode,
    Sum(od.Quantity) AS "Products Sold"
FROM
    Orders o
INNER JOIN
    [Order Details] od
ON
    od.OrderID = o.OrderID
WHERE
    DATEDIFF(year, GETDATE(), o.OrderDate) <= 27 AND
    o.ShipPostalCode IS NOT NULL
GROUP BY
    o.ShipPostalCode
ORDER BY [Products Sold] DESC;

-- 17. List all city names and number of customers in that city.     
SELECT
    c.City,
    count(c.CustomerId) As [Number of Customers]
FROM
    Customers c
GROUP BY
    c.city;

-- 18. List city names which have more than 2 customers, and number of customers in that city
SELECT
    c.City,
    count(c.CustomerId) As [Number of Customers]
FROM
    Customers c
GROUP BY
    c.city
HAVING
    count(c.CustomerId) > 2

-- 19. List the names of customers who placed orders after 1/1/98 with order date.
SELECT
    c.ContactName
FROM
    Customers c
INNER JOIN
    Orders o
ON
    c.CustomerId = o.CustomerId
WHERE
    o.OrderDate > '1/1/98'

-- 20. List the names of all customers with most recent order dates
SELECT
    c.ContactName,
    o.OrderDate
FROM
    Customers c
INNER JOIN
    Orders o
ON
    c.CustomerId = o.CustomerId
ORDER BY
    o.OrderDate DESC;

-- 21. Display the names of all customers  along with the  count of products they bought
SELECT
    c.ContactName,
    SUM(od.Quantity) AS [Count of Products]
FROM
    Customers c
LEFT JOIN
    Orders o
ON
    c.CustomerId = o.CustomerId
INNER JOIN
    [Order Details] od
ON
    o.OrderID = od.OrderId
GROUP BY
    c.ContactName

-- 22. Display the customer ids who bought more than 100 Products with count of products.
SELECT
    c.CustomerId,
    SUM(od.Quantity) AS [Count of Products]
FROM
    Customers c
LEFT JOIN
    Orders o
ON
    c.CustomerId = o.CustomerId
INNER JOIN
    [Order Details] od
ON
    o.OrderID = od.OrderId
GROUP BY
    c.CustomerId
HAVING
    SUM(od.Quantity) > 100

-- 23. List all of the possible ways that suppliers can ship their products. Display the results as below
--     Supplier Company Name                        Shipping Company Name
--     ---------------------------------            ----------------------------------
SELECT
    DISTINCT
    s.CompanyName AS [Supplier Company Name],
    sh.CompanyName AS [Shipping Company Name]
FROM
    Suppliers s
LEFT JOIN
    Products p
ON
    s.SupplierId = p.SupplierId
LEFT JOIN
    [Order Details] od
ON
    p.ProductId = od.ProductId
LEFT JOIN
    Orders o
ON
    od.OrderId = o.OrderId
LEFT JOIN
    Shippers sh
ON
    o.ShipVia = sh.ShipperId;

-- 24. Display the products order each day. Show Order date and Product Name.
SELECT
    DISTINCT
    o.OrderDate,
    p.ProductName
FROM
    Products p
LEFT JOIN
    [Order Details] od
ON
    p.ProductId = od.ProductId
LEFT JOIN
    Orders o
ON
    od.OrderId = o.OrderId;

-- 25. Displays pairs of employees who have the same job title.
SELECT
    e1.Title,
    e1.FirstName + ' ' + e1.LastName AS [First Employee],
    e2.FirstName + ' ' + e2.LastName AS [Second Employee]
FROM
    Employees e1
INNER JOIN
    Employees e2
ON
    e1.Title = e2.Title

-- 26. Display all the Managers who have more than 2 employees reporting to them.
SELECT
    m.FirstName + ' ' + m.LastName AS [Managers],
    Count(e.EmployeeId) AS [Employees Managed]
FROM
    employees e
INNER JOIN
    employees m
ON
    e.ReportsTo = m.EmployeeId
Group BY
    m.FirstName + ' ' + m.LastName
HAVING 
    Count(e.EmployeeId) > 2

-- 27. Display the customers and suppliers by city. The results should have the following columns
-- City
-- Name
-- Contact Name,
-- Type (Customer or Supplier)

SELECT
    c.City,
    c.CompanyName AS Name,
    c.ContactName AS [Contact Name],
    'Customer' AS Type
FROM
    Customers c
UNION ALL
SELECT
    s.City,
    s.CompanyName AS Name,
    s.ContactName AS [Contact Name],
    'Supplier' AS Type
FROM
    Suppliers s
-- SELECT
--     c.City AS customer,
--     s.City AS supplier
-- FROM
--     Customers c
-- FULL JOIN
--     Orders o
-- ON
--     c.CustomerId = o.CustomerId
-- FULL JOIN
--     [Order Details] od
-- ON
--     o.OrderId = od.OrderId
-- FULL JOIN
--     Products p
-- ON
--     od.ProductId = p.ProductId
-- FULL JOIN
--     Suppliers s
-- ON
--     p.SupplierId = s.SupplierId
-- ORDER BY
--     c.City,
--     s.City