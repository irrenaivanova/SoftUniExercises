CREATE DATABASE [Service]
--Problem 01
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME,
	Age INT CONSTRAINT CHK_AgeRange CHECK (Age BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(20) NOT NULL 
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME,
	Age INT CONSTRAINT CHK_AgeRange2 CHECK (Age BETWEEN 14 AND 110),
	DepartmentId INT  FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id)
)


CREATE TABLE Reports
(
Id INT PRIMARY KEY IDENTITY,
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
StatusId INT NOT NULL FOREIGN KEY REFERENCES [Status](Id),
OpenDate DATETIME NOT NULL,
CloseDate DATETIME,
[Description] VARCHAR(200),
UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)


--Problem 02
INSERT INTO Employees(FirstName, LastName, Birthdate, DepartmentId)
VALUES
('Marlo','O''Malley','1958-9-21',1),
('Niki', 'Stanaghan', '1969-11-26',4),
('Ayrton','Senna','1960-03-21',9),
('Ronnie','Peterson','1944-02-14',9),
('Giovanna','Amati','1959-07-20',5)

INSERT INTO Reports(CategoryId,	StatusId,OpenDate,	CloseDate,	[Description],	UserId,EmployeeId)
VALUES
(1,	1,'2017-04-13',NULL,   'Stuck Road on Str.133',	6,	2),
(6,	3,'2015-09-05','2015-12-06','Charity trail running',	3,	5),
(14,2,'2015-09-07',NULL	, 'Falling bricks on Str.58',	5,	2),
(4,	3,'2017-07-03','2017-07-06',	'Cut off streetlight on Str.11',1	,1)

--Problem 03
UPDATE Reports
   SET CloseDate = GETDATE()
 WHERE CloseDate IS NULL 

 --Problem 04
 DELETE Reports
  WHERE StatusId = 4 

--Problem 05
SELECT [Description],FORMAT(OpenDate,'dd-MM-yyyy') AS OpenDate
  FROM Reports
 WHERE EmployeeId IS NULL
 ORDER BY Reports.OpenDate, [Description]

 --Problem 06
SELECT r.[Description],c.[Name] AS CategoryName
  FROM Reports AS r
  LEFT JOIN Categories AS c ON c.Id =r.CategoryId
 WHERE r.CategoryId IS NOT NULL 
 ORDER BY r.[Description],c.[Name]

 --Problem 07

SELECT TOP(5)
	   c.[Name] AS CategoryName, COUNT(*) AS ReportsNumber
  FROM Reports AS r
  LEFT JOIN Categories AS c ON c.Id =r.CategoryId
 GROUP BY c.[Name]
 ORDER BY ReportsNumber DESC,CategoryName

 --Problem 08
SELECT u.Username,c.Name AS CategoryName
  FROM Reports AS r
  LEFT JOIN Users AS u ON u.Id = r.UserId
  LEFT JOIN Categories AS c ON c.Id = r.CategoryId
 WHERE MONTH(r.OpenDate) = MONTH (u.Birthdate)
   AND DAY(r.OpenDate) = DAY (u.Birthdate)
 ORDER BY u.Username,CategoryName 

 --Problem 09

WITH CTE_info AS
(SELECT CONCAT_WS (' ',e.FirstName,e.LastName) AS FullName, u.[Name] AS Users
  FROM Employees AS e
  LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
  LEFT JOIN Users AS u ON r.UserId = u.Id)

SELECT i.FullName,COUNT(DISTINCT(i.Users)) AS UsersCount
  FROM CTE_info AS i
 GROUP BY i.FullName
 ORDER BY UsersCount DESC, FullName

 ---
SELECT CONCAT_WS (' ',e.FirstName,e.LastName) AS FullName,
	   COUNT(DISTINCT(r.UserId)) AS UsersCount
  FROM Employees AS e
  LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
 GROUP BY e.Id,e.FirstName,e.LastName
 ORDER BY UsersCount DESC, FullName

 --Problem 10
-- Select all info for reports along with employee 
-- first name and last name (concataned with space), 
-- their department name, category name, report description,
-- open date, status label and name of the user. Order 
-- them by first name (descending), last name (descending),
-- department (ascending), category (ascending), description (ascending), 
-- open date (ascending), status (ascending) and user (ascending).
--Date should be in format 'dd.MM.yyyy'.
--If there are empty records, replace them with 'None'.
--Example
--Employee	Department	Category	Description	OpenDate	Status	User

SELECT CASE 
	   WHEN e.FirstName IS NULL THEN 'None'
	   ELSE CONCAT_WS(' ',e.FirstName,e.LastName) 
	   END AS Employee,
	   CASE
	   WHEN d.[Name] IS NULL THEN 'None'
	   ELSE d.[Name]
	   END AS Department,
	   c.[Name] AS Category,
	   r.[Description],
	   FORMAT (r.OpenDate,'dd.MM.yyyy') AS OpenDate,
	   st.Label AS [Status],
	   u.[Name] AS [User]
  FROM Reports AS r
  LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
  LEFT JOIN Departments AS d ON d.Id=e.DepartmentId
  LEFT JOIN Categories AS c ON c.Id =r.CategoryId 
  LEFT JOIN [Status] AS st ON st.Id = r.StatusId
  LEFT JOIN Users AS u ON u.Id = r.UserId
 ORDER BY e.FirstName DESC,e.LastName DESC, Department,Category,r.[Description],r.OpenDate,[Status],[User]

--Problem 11

CREATE OR ALTER FUNCTION udf_HoursToComplete (@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT AS
BEGIN
	DECLARE @Result INT
	IF @StartDate IS NULL OR @EndDate IS NULL
		SET @Result = 0
	ELSE
		SET @Result = DATEDIFF(HOUR,@StartDate,@EndDate)
	RETURN @Result
END

--Problem 12
--Create a stored procedure with the name usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
--that receives an employee's Id and a report's Id and assigns the
--employee to the report only if the department of the employee and 
--the department of the report's category are the same. Otherwise throw an exception with message: 
--"Employee doesn't belong to the appropriate department!". 

CREATE OR ALTER PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS
BEGIN TRANSACTION
	DECLARE @DepIdEmployee INT = (SELECT TOP(1)DepartmentId FROM Employees WHERE Id = @EmployeeId)
	DECLARE @DepIdReport INT = (SELECT TOP (1) c.DepartmentId 
								  FROM Reports AS r 
								  LEFT JOIN Categories AS c ON c.Id= r.CategoryId
								 WHERE r.Id = @ReportId)
	IF (@DepIdEmployee<>@DepIdReport)
	BEGIN
		ROLLBACK
		RAISERROR ('Employee doesn''t belong to the appropriate department!',16,1)
		RETURN
	END
	UPDATE Reports
	   SET EmployeeId = @EmployeeId 
     WHERE Id =@ReportId 
COMMIT

EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2