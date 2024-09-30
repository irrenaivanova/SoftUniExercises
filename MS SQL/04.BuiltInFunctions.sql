
SELECT * FROM Customers
SELECT CONCAT(LEFT(PaymentNumber,6),REPLICATE('*',LEN(PaymentNumber)-6))
FROM Customers

SELECT * , CEILING(CAST (Quantity AS float)/BoxCapacity/PalletCapacity) AS [Numbers of pallets]
FROM Products

SELECT [InvoiceId],Total,DATEPART(QUARTER, InvoiceDate),Month(InvoiceDate) AS 'Month', YEAR(InvoiceDate)AS YEAR, DAY(InvoiceDate) AS 'Day' 
FROM Invoices

--Exercises
--Ex.1
SELECT * FROM Employees
SELECT FirstName,LastName 
  FROM Employees
 WHERE FirstName LIKE 'Sa%'

 --Ex.2
 SELECT FirstName,LastName 
   FROM Employees
  WHERE LastName LIKE '%ei%'

--Ex.3
SELECT FirstName
  FROM Employees
 WHERE DepartmentID IN (3,10) AND YEAR(HireDate)  BETWEEN 1995 AND 2005


--Ex.4
SELECT FirstName, LastName
  FROM Employees
 WHERE JobTitle NOT LIKE '%engineer%'

SELECT * FROM Towns

--Ex.5
SELECT [Name]
  FROM Towns
 WHERE LEN([Name]) IN (5,6)
 ORDER BY [Name]

--Ex.6
SELECT TownID,[Name]
  FROM Towns
 WHERE LEFT([Name],1) IN ('M','K', 'B', 'E')
 ORDER BY [Name]

--Ex.7
SELECT TOwnID, [Name]
FROM Towns
WHERE LEFT([Name],1) NOT IN ('R','B','D')
ORDER BY [Name]

--Ex.8
GO
CREATE VIEW V_EmployeesHiredAfter2000 
  AS SELECT FirstName, LastName
       FROM Employees
      WHERE DATEPART(YEAR,HireDate) > 2000
SELECT * FROM V_EmployeesHiredAfter2000

--Ex.9
SELECT FirstName, LastName
  FROM Employees
  WHERE LEN(LastName) = 5

--Ex.10
SELECT EmployeeID,FirstName,LastName,Salary,
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS 'Rank'
  FROM Employees
  WHERE Salary BETWEEN 10000 AND 50000
  ORDER BY Salary DESC

--Ex.11
SELECT *
FROM (
		SELECT EmployeeID,FirstName,LastName,Salary,
				DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) 
			AS 'Rank'
		  FROM Employees
          WHERE Salary BETWEEN 10000 AND 50000
     )AS RankingSubquery
WHERE RANK=2
ORDER BY Salary DESC

--Ex.12
SELECT CountryName,IsoCode
  FROM Countries
 WHERE CountryName LIKE '%a%a%a%'
 ORDER BY IsoCode

--Ex.13
SELECT PeakName,RiverName,CONCAT(LOWER(LEFT(PeakName,LEN(PeakName)-1)),LOWER(RiverName)) AS Mix
  FROM Peaks AS p,
       Rivers AS r
 WHERE RIGHT(p.PeakName,1)=LEFT(r.RiverName,1)
 ORDER BY Mix


 --Ex.14
SELECT TOP(50) [Name],FORMAT([Start],'yyyy-MM-dd') AS [Start]
  FROM Games
WHERE YEAR([Start]) BETWEEN 2011 AND 2012
ORDER BY [Start],[Name]

--Ex.15
SELECT UserName,SUBSTRING(Email,CHARINDEX('@',Email)+1,LEN(Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider],Username

--Ex.16
SELECT Username,IpAddress AS [IP Address]
  FROM Users
 WHERE IpAddress LIKE '___.1%_.%_.___'
 ORDER BY Username

 --Ex.17
 SELECT [Name] AS Game,
		CASE
			WHEN DATEPART(HOUR,[Start])>=0 AND DATEPART(HOUR,[Start])<12 THEN 'Morning'
			WHEN DATEPART(HOUR,[Start])>=12 AND DATEPART(HOUR,[Start])<18 THEN 'Afternoon'
		    WHEN DATEPART(HOUR,[Start])>=18 AND DATEPART(HOUR,[Start])<24 THEN 'Evening'
		END AS [Part of the Day],	
	   CASE 
			WHEN Duration <=3 THEN 'Extra Short'
			WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
			WHEN Duration >6 THEN 'Long'
			ELSE 'Extra Long'
		END AS Duration
   FROM Games
  WHERE [Start] IS NOT NULL 
 ORDER BY Game,Duration,[Part of the Day]

 --Ex.18
 SELECT ProductName,
		OrderDate,
		DATEADD(DAY,3,OrderDate) AS [Pay Due],
		DATEADD(MONTH,1,OrderDate) AS [Deliver Due]
   FROM Orders

--Ex.19
CREATE TABLE People
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
Birthday DATETIME2 NOT NULL
)

INSERT INTO People
	VALUES
('Victor','2000-12-07'),
('Steven', '1992-09-10'),
('Stephen','1910-09-19'),
('John','2010-01-06')

SELECT DATEDIFF(YEAR,Birthday,GETDATE()) AS [Age in Years],
	   DATEDIFF(MONTH,Birthday,GETDATE()) AS [Age in Months],
	   DATEDIFF(DAY,Birthday,GETDATE()) AS [Age in Days],
	   DATEDIFF(MINUTE,Birthday,GETDATE()) AS [Age in Minutes]
  FROM People