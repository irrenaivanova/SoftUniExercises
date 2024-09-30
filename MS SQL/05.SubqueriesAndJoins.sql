SELECT TOP(50) e.FirstName,e.LastName,t.[Name] AS Town, a.AddressText 
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON t.Id = a.TownID
ORDER BY FirstName, LastName


SELECT TOP(50)
	   e.EmployeeID,
	   CONCAT_WS(' ',e.FirstName,e.LastName) AS [FullName],
	   CONCAT_WS(' ',em.FirstName,em.LastName) AS ManagerName,
	   d.[Name] AS DepartmentID 
  FROM Employees AS e
  JOIN Employees AS em  ON e.ManagerID=em.EmployeeID
  JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
  ORDER BY e.EmployeeID

---
SELECT d.[Name] AS DepartmentName,
       sub.[Avg Salary] AS [MinAvgSalary] 
FROM
	(SELECT TOP(1) DepartmentID,ROUND(AVG(Salary),2) AS [Avg Salary]
	FROM Employees AS e
	GROUP BY e.DepartmentID
	ORDER BY [Avg Salary] 
	) AS sub
JOIN Departments AS d ON d.DepartmentID= sub.DepartmentID

SELECT * FROM Addresses
-- Ex.01
SELECT TOP 5
	   e.EmployeeID,
	   e.JobTitle,
	   e.AddressID,
	   a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID 
ORDER BY e.AddressID

--Ex.02
SELECT TOP 50
	   e.FirstName,
	   e.LastName,
	   t.[Name] AS Town,
	   a.AddressText
  FROM Employees AS e
  JOIN Addresses AS a ON e.AddressID = a.AddressID
  JOIN Towns AS t ON a.TownID = t.TownID
 ORDER BY e.FirstName,e.LastName

 --Ex.03
SELECT  e.EmployeeID,
		e.FirstName,
		e.LastName,
		dep.[Name]
  FROM Employees AS e
		JOIN  (SELECT d.DepartmentID,d.Name
				   FROM Departments AS d
				   WHERE [Name] = 'Sales'  
			   ) AS dep 
	ON dep.DepartmentID = e.DepartmentID	 
 ORDER BY e.EmployeeID

 --Ex.04
 SELECT TOP 5
		e.EmployeeID, 
		e.FirstName,
		e.Salary,
		d.[Name] AS DepartmentName
   FROM Employees AS e
   JOIN Departments AS d ON e.DepartmentID=d.DepartmentID
  WHERE Salary>15000
  ORDER BY d.DepartmentID

--Ex.05
    SELECT 
			e.EmployeeID,
			e.FirstName,
			ep.ProjectID
     FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID=ep.EmployeeID
    WHERE ep.ProjectID IS NULL
 ORDER BY e.EmployeeID

-- Ex.06
SELECT e.FirstName,e.LastName,e.HireDate,depN.[Name] AS DeptName
  FROM Employees AS e
LEFT JOIN 
		(SELECT DepartmentID,[Name]
		   FROM Departments) 
		     AS depN ON depN.DepartmentID = e.DepartmentID
WHERE e.HireDate >1999-1-1
  AND depN.[Name] IN ('Sales', 'Finance')

-- Demo for me 
SELECT EmployeeID,
	   CASE FirstName
	   WHEN 'Guy' THEN 'dsjhdsj'
	   ELSE FirstName
	   END AS FirstName,
	   LastName
  FROM Employees

--Ex.07
SELECT TOP 5
	   e.EmployeeID,e.FirstName,
	   p.[Name] AS ProjectName 
  FROM Employees AS e
	   JOIN EmployeesProjects AS ep 
         ON e.EmployeeID = ep.EmployeeID
       
	   JOIN Projects AS p
	     ON p.ProjectID = ep.ProjectID 
 WHERE p.StartDate > 2002-08-13
       AND p.EndDate IS NULL
 ORDER BY EmployeeID


 --Ex.08
SELECT e.EmployeeID,e.FirstName,
	   CASE
	   WHEN DATEPART(YEAR,p.StartDate)>=2005 THEN 'NULL'
	   ELSE p.[Name]
	   END AS ProjectName
  FROM Employees AS e
	   JOIN EmployeesProjects AS ep 
	   ON e.EmployeeID = ep.EmployeeID
	  
	   JOIN Projects AS p
	   ON p.ProjectID = ep.ProjectID
 WHERE e.EmployeeID = 24
SELECT *
FROM Projects

--Ex.09
SELECT e.EmployeeID,e.FirstName,e.ManagerID,
	   m.FirstName AS ManagerName
  FROM Employees AS e
  JOIN Employees AS m ON m.EmployeeID = e.ManagerID
 WHERE e.ManagerID IN (3,7)
 ORDER BY e.EmployeeID

--Ex.10
SELECT TOP 50
	   e.EmployeeID, CONCAT_WS (' ',e.FirstName,e.LastName) AS EmployeeName,
	   CONCAT_WS(' ',m.FirstName,m.LastName) AS ManagerName,
	   d.[Name] AS DepartmentName 
  FROM Employees AS e
  JOIN Employees AS m ON e.ManagerID = m.EmployeeID
  JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
 ORDER BY e.EmployeeID

 --Ex.11

-- no name of the department
 SELECT MIN(avgd.AverageSalary)
  FROM ((SELECT DepartmentID,
	   AVG(Salary) AS AverageSalary
	   FROM Employees
       GROUP BY DepartmentID) AS avgd		   
  JOIN Departments AS d ON d.DepartmentID=avgd.DepartmentID)

-- no min number
SELECT d.Name,avgd.AverageSalary 
  FROM (SELECT DepartmentID,
	   AVG(Salary) AS AverageSalary
	   FROM Employees
       GROUP BY DepartmentID
	   ) AS avgd		   
  JOIN Departments AS d ON d.DepartmentID=avgd.DepartmentID

--CTE(Common Table Expression)
WITH AvgSalaries AS
     (SELECT DepartmentID,
	   AVG(Salary) AS AverageSalary
	   FROM Employees
       GROUP BY DepartmentID) 		   
  
SELECT d.[Name],
	   av.AverageSalary
  FROM AvgSalaries AS av
  JOIN Departments AS d ON d.DepartmentID = av.DepartmentID
 WHERE AverageSalary = (SELECT MIN(AverageSalary) FROM AvgSalaries);

-- no min number
WITH AvgSalary AS
(SELECT d.Name,AVG(e.Salary) AS AvgS
  FROM Employees AS e
  JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
 GROUP BY e.DepartmentID,d.Name)

SELECT [Name],AvgS
  FROM AvgSalary 
 WHERE AvgS = (SELECT MIN(AvgS) FROM AvgSalary)

 --Ex.12
 SELECT c.CountryCode
	    ,m.MountainRange
		,p.PeakName
		,p.Elevation
   FROM MountainsCountries AS mc
   JOIN Countries AS c ON mc.CountryCode = c.CountryCode
   JOIN Mountains AS m ON mc.MountainId = m.Id
   JOIN Peaks AS p ON m.Id = p.MountainId
  WHERE c.CountryCode = 'BG'
		AND p.Elevation > 2835
  ORDER BY p.Elevation DESC	
  
--Ex.13
   SELECT c.CountryCode, COUNT(mc.MountainId)
     FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
    WHERE c.CountryName IN ('United States','Russia', 'Bulgaria')
 GROUP BY c.CountryCode

--Ex.14
   SELECT TOP 5
	      c.CountryName, r.RiverName
     FROM Countries AS c
     JOIN Continents AS co ON c.ContinentCode = co.ContinentCode
LEFT JOIN CountriesRivers AS cs ON cs.CountryCode = c.CountryCode 
LEFT JOIN Rivers AS r ON r.Id = cs.RiverId
    WHERE ContinentName = 'Africa' 
 ORDER BY c.CountryName

--Ex.15
WITH ContinentCurrency AS 
  (SELECT ContinentCode,CurrencyCode,Count(*) AS CurrencyUsage
    FROM Countries
GROUP BY ContinentCode,
		 CurrencyCode
HAVING COUNT(*)>1)

SELECT r.ContinentCode,
	   r.CurrencyCode,
	   r.CurrencyUsage
FROM
       (SELECT ContinentCode,
	           CurrencyCode,
			   CurrencyUsage,
			   RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC) AS rv
		  FROM ContinentCurrency) AS r
WHERE r.rv=1
ORDER BY  r.ContinentCode
  
--Ex.16
SELECT COUNT(*) AS [Count]
FROM
   (SELECT c.CountryCode,mc.MountainId 
     FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
    WHERE MountainId IS NULL) AS a

--Ex.17
WITH CountryRiver AS
 (SELECT cr.CountryCode,cr.[Length]
 FROM
		(SELECT c.CountryCode,r.RiverName,r.[Length],
		  RANK() OVER (PARTITION BY CountryName ORDER BY r.[Length] DESC) AS rr
     FROM Countries AS c
LEFT JOIN CountriesRivers AS cs ON c.CountryCode = cs.CountryCode
LEFT JOIN Rivers AS r ON cs.RiverId = r.Id) AS cr
    WHERE cr.rr = 1)


SELECT  TOP 5
		cp.CountryName,cp.Elevation,cr.[Length]
  FROM (SELECT c.CountryCode,m.MountainRange,p.PeakName,p.Elevation,c.CountryName,
		   RANK() OVER (PARTITION BY c.CountryCode ORDER BY p.Elevation DESC) AS pr
      FROM Countries AS c
 LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
 LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
 LEFT JOIN Peaks AS p ON p.MountainId = m.Id) AS cp
      JOIN CountryRiver as cr ON cr.CountryCode = cp.CountryCode
	 WHERE cp.pr = 1
  ORDER BY cp.Elevation DESC, cr.[Length] DESC, cp.CountryName
	 
-- Ex.17 - 2 - THE RIGHT WAY
   SELECT TOP 5
		  c.CountryName ,MAX(p.ELevation)AS PeakEL,MAX(r.Length) AS LengthR
     FROM Countries AS c
LEFT JOIN CountriesRivers AS cs ON cs.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id= cs.RiverId
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p ON p.MountainId = m.Id
 GROUP BY c.CountryName
 ORDER BY PeakEL DESC, LengthR DESC, CountryName

--Ex.18
WITH CTE_rank AS
   (SELECT c.CountryName AS Country,
     CASE 
		      WHEN p.PeakName IS NULL THEN '(no highest peak)'
			  ELSE p.PeakName
			  END [Highest Peak Name],
		  CASE 
		      WHEN p.Elevation IS NULL THEN 0
			  ELSE p.Elevation
			  END [Highets Peak ELevation],
		  CASE 
		      WHEN  m.MountainRange IS NULL THEN '(no mountain)'
			  ELSE m.MountainRange
			  END Mountain,
		  DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.ELevation DESC) AS re 	     
     FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON p.MountainId = m.Id)

  SELECT TOP 5
		 ra.Country,ra.[Highest Peak Name],ra.[Highets Peak ELevation],ra.Mountain
    FROM CTE_rank AS ra
   WHERE ra.re = 1 
ORDER BY ra.Country,ra.[Highest Peak Name]

 

		 