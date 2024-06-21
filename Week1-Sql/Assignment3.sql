USE Northwind
GO

-- 1. List all cities that have both Employees and Customers.
SELECT
    DISTINCT
    c.City
FROM
    Employees e
INNER JOIN
    Customers c
ON
    e.City = c.City

-- 2. List all cities that have Customers but no Employee.

--     a. Use sub-query
SELECT
    DISTINCT
    c.City
FROM
    Customers c
WHERE
    c.City NOT IN
(
    SELECT
        e.City
    FROM
        Employees e
) 

--     b. Do not use sub-query
SELECT
    DISTINCT
    c.City
FROM
    Customers c
LEFT JOIN
    Employees e
ON
    c.City = e.City
WHERE
    e.EmployeeID IS NULL;

-- 3. List all products and their total order quantities throughout all orders.
SELECT
    p.ProductName,
    SUM(od.quantity)
FROM
    Products p
LEFT JOIN
    [Order Details] od
ON
    p.ProductID = od.ProductID
GROUP BY
    p.ProductName

-- 4. List all Customer Cities and total products ordered by that city.
SELECT 
    c.City, 
    (SELECT 
        SUM(od.Quantity)
    FROM 
        Orders o
    JOIN 
        [Order Details] od 
    ON 
        o.OrderID = od.OrderID
    WHERE 
        o.CustomerID = c.CustomerID) AS TotalProductsOrdered
FROM 
    Customers c
GROUP BY 
    c.City,
    c.CustomerID
ORDER BY 
    TotalProductsOrdered DESC;

-- 5. List all Customer Cities that have at least two customers.
SELECT
    c.City,
    COUNT(c.CustomerID) AS [No of Customers]
FROM
    Customers c
GROUP BY
    c.City
HAVING
    COUNT(c.CustomerID) >= 2;

--     a. Use union
SELECT
    c.City,
    COUNT(c.CustomerID) AS [No of Customers]
FROM
    Customers c
GROUP BY
    c.City
HAVING
    COUNT(c.CustomerID) = 2
UNION
SELECT
    c.City,
    COUNT(c.CustomerID) AS [No of Customers]
FROM
    Customers c
GROUP BY
    c.City
HAVING
    COUNT(c.CustomerID) > 2;

--     b. Use sub-query and no union
SELECT 
    oc.City,
    (SELECT 
        COUNT(*)
    FROM 
        Customers AS ic
    WHERE 
        ic.City = oc.City) AS [No of Customers]
FROM 
    Customers AS oc
WHERE (
    SELECT 
        COUNT(*)
    FROM 
        Customers AS ic
    WHERE 
        ic.City = oc.City) >= 2
GROUP BY 
    oc.City;


-- 6. List all Customer Cities that have ordered at least two different kinds of products.
SELECT 
    c.City, 
    COUNT(DISTINCT od.ProductID) AS [Product Variety]
FROM 
    Customers c
JOIN 
    Orders o 
ON 
    c.CustomerID = o.CustomerID
JOIN
    [Order Details] od
ON
    od.OrderID = o.OrderID
GROUP BY 
    c.City
HAVING 
    COUNT(DISTINCT od.ProductID) >= 2;

-- 7. List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
SELECT 
    DISTINCT
    c.ContactName, 
    c.City AS CustomerCity, 
    o.ShipCity
FROM 
    Customers c
JOIN 
    Orders o 
ON 
    c.CustomerID = o.CustomerID
WHERE 
    c.City <> o.ShipCity;

-- 8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.

WITH ProductSales AS (
    SELECT 
        p.ProductID,
        p.ProductName,
        AVG(od.UnitPrice) AS AveragePrice,
        SUM(od.Quantity) AS TotalQuantitySold
    FROM 
        Products p
    INNER JOIN 
        [Order Details] od 
    ON 
        p.ProductID = od.ProductID
    GROUP BY 
        p.ProductID, p.ProductName
),
RankedCities AS (
    SELECT 
        od.ProductID,
        c.City,
        SUM(od.Quantity) AS CityQuantity,
        RANK() OVER (PARTITION BY od.ProductID ORDER BY SUM(od.Quantity) DESC) AS CityRank
    FROM 
        [Order Details] od
    INNER JOIN 
        Orders o 
    ON 
        od.OrderID = o.OrderID
    INNER JOIN 
        Customers c 
    ON 
        o.CustomerID = c.CustomerID
    GROUP BY 
        od.ProductID, c.City
)

SELECT 
    Top 5
    ps.ProductName,
    ps.AveragePrice,
    rc.City
FROM 
    ProductSales ps
JOIN (
        SELECT 
            ProductID, 
            City
        FROM 
            RankedCities
        WHERE 
            CityRank = 1
    ) rc 
ON 
    ps.ProductID = rc.ProductID
ORDER BY 
    ps.TotalQuantitySold DESC

-- 9. List all cities that have never ordered something but we have employees there.

--     a. Use sub-query
SELECT 
    DISTINCT 
    e.City
FROM 
    Employees e
WHERE 
    NOT EXISTS (
        SELECT 
            1
        FROM 
            Orders o
        WHERE 
            o.ShipCity = e.City
    );

--     b. Do not use sub-query
SELECT 
    DISTINCT 
    e.City
FROM 
    Employees e
LEFT JOIN 
    Orders o 
ON 
    e.City = o.ShipCity
WHERE 
    o.OrderID IS NULL;


-- 10. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
WITH EmployeeSales AS (
    SELECT 
        e.City AS EmployeeCity,
        COUNT(o.OrderID) AS TotalOrders,
        RANK() OVER (ORDER BY COUNT(o.OrderID) DESC) AS OrderRank
    FROM 
        Employees e
    JOIN 
        Orders o 
    ON 
        e.EmployeeID = o.EmployeeID
    GROUP BY 
        e.City
),
ProductSales AS (
    SELECT 
        c.City AS CustomerCity,
        SUM(od.Quantity) AS TotalQuantity,
        RANK() OVER (ORDER BY SUM(od.Quantity) DESC) AS QuantityRank
    FROM 
        [Order Details] od
    JOIN 
        Orders o 
    ON 
        od.OrderID = o.OrderID
    JOIN 
        Customers c 
    ON 
        o.CustomerID = c.CustomerID
    GROUP BY 
        c.City
)
SELECT 
    es.EmployeeCity AS [City Orders],
    ps.CustomerCity AS [City Products]
FROM 
    EmployeeSales es
JOIN 
    ProductSales ps 
ON 
    es.EmployeeCity = ps.CustomerCity
WHERE 
    es.OrderRank = 1 AND ps.QuantityRank = 1

-- 11. How do you remove the duplicates record of a table?
--ANSWER: 
-- We can use DISTINCT keyword in select to remove duplicates.
-- UNION to remove duplicates in a United table
-- We can remove duplicates record of a table by using ROW_NUMBER function along with CTE(common Table Procedures)
WITH CTE AS (
   SELECT *,
       ROW_NUMBER() OVER (
           PARTITION BY column1, column2, column3 
       ) AS row_num
   FROM tableName
)
DELETE FROM CTE
WHERE row_num > 1;
