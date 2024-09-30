SELECT DepartmentID,SUM(Salary) AS Total
  FROM Employees 
 GROUP BY DepartmentID
 
 SELECT *
   FROM WizzardDeposits

--Ex.01
SELECT COUNT(*) 
  FROM WizzardDeposits

--Ex.02
SELECT MAX(MagicWandSize)
  FROM WizzardDeposits

--Ex. 03
  SELECT DepositGroup,MAX(MagicWandSize) AS LongestMagicWand
    FROM WizzardDeposits
GROUP BY DepositGroup

--Ex.04
SELECT TOP 2
	   DepositGroup
  FROM WizzardDeposits
 GROUP BY DepositGroup
 ORDER BY AVG(MagicWandSize)

--Ex.05
SELECT DepositGroup,SUM(DepositAmount) AS TotalSum
   FROM WizzardDeposits
  GROUP BY DepositGroup

--Ex.06
  SELECT DepositGroup,SUM(DepositAmount) AS TotalSum
    FROM WizzardDeposits
   WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--Ex.07
  SELECT DepositGroup,SUM(DepositAmount) AS TotalSum
    FROM WizzardDeposits
   WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
  HAVING SUM(DepositAmount)<150000 
ORDER BY TotalSum DESC

--Ex.08
  SELECT DepositGroup,MagicWandCreator,MIN(DepositCharge) AS MinDepositCharge
    FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator,DepositGroup

--Ex.09
WITH SubQuery AS
(SELECT 
		CASE 
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
			END AS 'AgeGroup'
    FROM WizzardDeposits)

SELECT AgeGroup,COUNT(*)
  FROM SubQuery 
 GROUP BY AgeGroup

--Ex.10
  SELECT SUBSTRING(FirstName,1,1) AS FirstLetter,Count(*)
    FROM WizzardDeposits
   WHERE DepositGroup = 'Troll Chest'
GROUP BY SUBSTRING(FirstName,1,1)

--Ex.11
  SELECT DepositGroup,IsDepositExpired,AVG(DepositInterest) AS AverageInterest
    FROM WizzardDeposits
   WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup,IsDepositExpired
ORDER BY DepositGroup DESC,IsDepositExpired

--Ex.12
 WITH CompareSubQuary AS
 (SELECT Wd1.Id, wd1.FirstName AS [Host Wizard],
		 wd1.DepositAmount AS [Host Wizard Deposit],
		 wd2.FirstName AS [Guest Wizard],
		 wd2.DepositAmount AS [Guest Wizard Deposit],
		 wd2.DepositAmount-wd1.DepositAmount AS [Difference]
    FROM WizzardDeposits AS wd1
	JOIN WizzardDeposits AS wd2 ON wd1.Id = wd2.Id - 1)

SELECT ABS(SUM([Difference])) AS SumDifference
  FROM CompareSubQuary

  -- with LEAD()
SELECT FirstName,
	   DepositAmount,
	   LEAD(FirstName) OVER (ORDER BY Id) 
  FROM WizzardDeposits

--Ex.13
 SELECT DepartmentID,SUM(Salary) AS TotalSalary
   FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

--Ex.14
SELECT DepartmentID,MIN(Salary) AS MinimumSalary
  FROM Employees
 WHERE DepartmentID IN ('2','5','7')
       AND HireDate > '2000-01-01'
GROUP BY DepartmentID

--Ex.15
SELECT *
  INTO Employees30000
  FROM Employees
 WHERE Salary>30000

DELETE FROM Employees30000
WHERE ManagerID = 42

UPDATE Employees30000
   SET Salary +=5000
 WHERE DepartmentID = 1 

SELECT DepartmentID,Avg(Salary) AS AvgSalary 
FROM Employees30000
GROUP BY DepartmentID


--EX.16
SELECT DepartmentID,MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--Ex.17
SELECT COUNT(*) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

--Ex.18
SELECT DISTINCT(DepartmentID),Salary AS ThirdHighestSalary
  FROM 
		(SELECT DepartmentID,Salary,
			   DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
		  FROM Employees) AS sq
 WHERE [Rank] = 3 

--Ex.19
WITH av AS
(SELECT DepartmentID,AVG(Salary) AS AvgS
  FROM Employees
GROUP BY DepartmentID)

SELECT TOP 10 e.FirstName,e.LastName,e.DepartmentID
  FROM Employees AS e
  JOIN av ON e.DepartmentID = av.DepartmentID
 WHERE e.Salary > av.AvgS
 ORDER BY DepartmentID