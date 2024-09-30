--Problem 01
CREATE OR ALTER PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName,LastName 
	  FROM Employees
	 WHERE Salary > 35000
END

EXEC usp_GetEmployeesSalaryAbove35000

--Problem 02
CREATE OR ALTER PROC usp_GetEmployeesSalaryAboveNumber @SalaryLevel DECIMAL(18,4)
AS
BEGIN
	SELECT FirstName,LastName
	  FROM Employees
	 WHERE Salary>=@SalaryLevel
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--Problem 03
CREATE OR ALTER PROC usp_GetTownsStartingWith @startinString VARCHAR(20)
AS
BEGIN
	SELECT [Name]
	  FROM Towns
	 WHERE [Name] LIKE @startinString +'%'
END

EXEC usp_GetTownsStartingWith  'b'

--Problem 04
CREATE OR ALTER PROC usp_GetEmployeesFromTown @Town VARCHAR(50)
AS
BEGIN
	SELECT e.FirstName,e.LastName
	  FROM Employees AS e
	  JOIN Addresses AS ad ON e.AddressID = ad.AddressID
	  JOIN Towns AS t ON t.TownID = ad.TownID
     WHERE t.[Name]=@Town
END
EXEC usp_GetEmployeesFromTown 'Sofia'

--Problem 05
GO
CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @result VARCHAR(10)
	IF  @salary<30000  
	SET @result ='Low' 			 
	IF  @salary BETWEEN 30000 AND 50000 
	SET @result = 'Average'
	IF @salary > 50000
	SET @result = 'High'
	
	RETURN @result 
END
GO

SELECT Salary,
       dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
  FROM Employees	   
  

-- Problem 06
CREATE OR ALTER PROC usp_EmployeesBySalaryLevel @LevelSalary VARCHAR(10)
AS
BEGIN
	SELECT FirstName,LastName
	  FROM Employees
	 WHERE dbo.ufn_GetSalaryLevel(Salary)=@LevelSalary
END

EXEC usp_EmployeesBySalaryLevel 'high'

--Problem 07
CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT 
AS
BEGIN
	DECLARE @Result BIT
	DECLARE @Index INT
		SET @Index= 1
		WHILE (@Index<=LEN(@word))
		BEGIN
			IF CHARINDEX(SUBSTRING(@word,@Index,1),@setOfLetters)<>0
				BEGIN
					SET @Index+=1
				END
			ELSE
				BEGIN
				SET @Result = 0
				RETURN @Result
				END
		END
		SET @Result = 1
	RETURN @Result
END

SELECT dbo.ufn_IsWordComprised('oistmiahf','Sofia')
SELECT dbo.ufn_IsWordComprised('oistmiahf','halves')

SELECT CHARINDEX('m','abv')
SELECT SUBSTRING('abv',2,1)
SELECT CHARINDEX('l','abv')

SELECT FirstName FROM Employees
WHERE dbo.ufn_IsWordComprised('oistmiahf', FirstName) = 1

--Problem 08
CREATE OR ALTER PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	DECLARE @EmployeesToRemove TABLE(Id INT)
	INSERT INTO @EmployeesToRemove
			SELECT EmployeeID
			  FROM Employees
			 WHERE DepartmentID = 1
	DELETE
	  FROM EmployeesProjects
	 WHERE EmployeeID IN (SELECT * FROM @EmployeesToRemove)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT 

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT * FROM @EmployeesToRemove)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT * FROM @EmployeesToRemove)

	DELETE
	  FROM Employees 
     WHERE DepartmentID = @departmentId

	DELETE 
	  FROM Departments
	 WHERE  DepartmentID = @departmentId

	SELECT COUNT(*)
	  FROM Employees
     WHERE DepartmentID =@departmentId 
END

EXEC usp_DeleteEmployeesFromDepartment 1

--Problem 09
CREATE OR ALTER PROC usp_GetHoldersFullName 
AS
BEGIN
	SELECT CONCAT_WS(' ',FirstName,LastName) AS [Full Name] 
	  FROM AccountHolders
END

--Problem 10
CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan (@MinBalance MONEY)
AS
BEGIN
	SELECT a.FirstName,a.LastName 
	  FROM AccountHolders AS a
	  JOIN Accounts AS acc ON acc.AccountHolderId = a.Id
     GROUP BY acc.AccountHolderId,a.FirstName,a.LastName
	HAVING SUM (acc.Balance) > @MinBalance
	 ORDER BY a.FirstName,a.LastName
END


SELECT * FROM AccountHolders
SELECT * FROM Accounts

--Problem 11
CREATE OR ALTER FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(20,4),@yearlyInterest FLOAT,@years INT)
RETURNS DECIMAL(20,4)
AS
BEGIN
	DECLARE @result DECIMAL(20,4)
	SET @result = @sum * (POWER(1+@yearlyInterest,@years))
	RETURN @result
END

--Problem 12
CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount @AccountID INT,@rate FLOAT
AS
BEGIN
	SELECT acc.Id,
		   ah.FirstName,ah.LastName,
		   acc.Balance AS [Current Balance],
		   dbo.ufn_CalculateFutureValue (acc.Balance,@rate,5) AS [Balance in 5 years]
	  FROM Accounts AS acc
	  JOIN AccountHolders AS ah ON ah.Id = acc.AccountHolderId
	 WHERE acc.Id = @AccountID
END

--Problem 13
CREATE OR ALTER FUNCTION ufn_CashInUsersGames (@GameName NVARCHAR(50))
RETURNS TABLE 
AS
RETURN
(
	SELECT SUM(Cash) AS SumCash
	  FROM 
(SELECT Cash,Ranking,GameId
	   FROM

			(SELECT *,ROW_NUMBER() OVER(ORDER BY Cash DESC) AS Ranking
			   FROM UsersGames
			   WHERE GameId = (SELECT Id
							   FROM Games
							  WHERE [Name] = @GameName)
			   ) AS r
			   WHERE Ranking%2 = 1
			) AS sub	
);


CREATE OR ALTER FUNCTION udf_IsOdd (@Ranking INT)
RETURNS BIT
BEGIN
	IF @Ranking%2=0
	RETURN 0
	ELSE
	RETURN 1
END

CREATE OR ALTER FUNCTION udf_IsOdd (@Ranking INT)
RETURNS BIT
BEGIN
	DECLARE @Result BIT
	IF @Ranking%2=0
	SET @Result = 0
	ELSE
	SET @Result = 1
	RETURN @Result
END