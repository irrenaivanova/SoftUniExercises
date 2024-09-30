SELECT *
  FROM AccountHolders

SELECT *
  FROM Accounts

CREATE TABLE AccountChanges
(
	Id INT PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
	OldAmount MONEY NOT NULL,
	NewAmount MONEY NOT NULL,
	DateOfChange DATETIME NOT NULL
)
SELECT *
  FROM AccountChanges

CREATE TRIGGER tr_OnAccountChangeAddLogRecords
ON Accounts FOR UPDATE
AS
BEGIN
	 INSERT INTO AccountChanges (AccountId,OldBalance,NewBalance,DateOfChange)
	 SELECT i.Id, d.Balance, i.Balance, GETDATE() 
	   FROM inserted AS i
	   JOIN deleted AS d ON i.Id = d.Id

END

CREATE TRIGGER tr_DeleteAccountHolderSetIsDeleted
ON AccountHolders INSTEAD OF DELETE
AS
BEGIN
	UPDATE AccountHolders
	   SET IsDeleted = 1
	 WHERE Id IN (SELECT Id FROM deleted)
END

--Exrecises
--Problem 01
CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)

CREATE OR ALTER TRIGGER tr_Logs_by_accountchanging
ON Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO Logs(AccountId,OldSum,NewSum)
	SELECT i.Id,d.Balance,i.Balance
      FROM inserted As i 
	  JOIN deleted AS d ON i.Id=d.Id
	 WHERE d.Balance<>i.Balance
END

--Problem 02
CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
	[Subject] VARCHAR(50) NOT NULL, 
	Body VARCHAR(100) NOT NULL
)
GO
CREATE  FUNCTION udf_text_foremail_subject(@AccoutnId INT)
RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @textSubject VARCHAR(50)
	SET @textSubject = CONCAT_WS(' ','Balance change for account:',@AccoutnId)
	RETURN @textSubject
END
GO

CREATE  FUNCTION udf_textforemail_Body(@OldMoney MONEY, @NewMoney MONEY)
RETURNS VARCHAR (100)
AS
BEGIN
	DECLARE @textBody VARCHAR (100)
	SET @textBody =	CONCAT_WS(' ','On',
					FORMAT(GETDATE(), 'MMM dd yyyy h:mm tt'),
					'your balance was changed from',
					@OldMoney,'to',@NewMoney) 
	RETURN @textBody
END
GO

CREATE TRIGGER tg_NotificationEmail_WhenAccountChange
ON Logs FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails (Recipient,[Subject],Body)
	SELECT 
		   AccountId,
	       dbo.udf_text_foremail_subject(AccountId),
		   dbo.udf_textforemail_Body(OldSum,NewSum)
	  FROM inserted
END
GO

UPDATE Accounts
   SET Balance -= 5
 WHERE Id = 5

SELECT FORMAT(GETDATE(), 'MMM dd yyyy h:mm tt')

SELECT * FROM NotificationEmails
SELECT * FROM Logs
SELECT * FROM AccountHolders
SELECT * FROM Accounts

DROP TABLE Logs

--Problem 03
CREATE OR ALTER PROCEDURE usp_DepositMoney @AccountId INT,@MoneyAmount DECIMAL(15,4)
AS
BEGIN TRANSACTION
	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @AccountId)

	IF @account IS NULL
	BEGIN
		ROLLBACK
		RAISERROR ('Invalid account',16,1)
		RETURN
	END

	IF @MoneyAmount<0
	BEGIN
		ROLLBACK
		RAISERROR ('Negative ammount',16,1)
		RETURN
	END

	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId
COMMIT

--Problem 04
CREATE OR ALTER PROC usp_WithdrawMoney (@AccountId INT,@MoneyAmount DECIMAL(15,4))
AS
BEGIN TRANSACTION
	IF NOT EXISTS(SELECT * FROM Accounts WHERE Id  = @AccountId)
	BEGIN
		ROLLBACK
		RAISERROR ('Invalid usser',16,1)
		RETURN
	END

	IF @MoneyAmount > (SELECT Balance FROM Accounts WHERE Id = @AccountId)
	BEGIN
		ROLLBACK
		RAISERROR ('Insufficient amount',16,1)
		RETURN
	END

	UPDATE Accounts
	SET Balance -=@MoneyAmount
	WHERE Id = @AccountId
COMMIT

--Problem 05
CREATE OR ALTER PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15,4))
AS
BEGIN TRANSACTION
	IF NOT EXISTS (SELECT * FROM Accounts WHERE Id = @SenderId) OR
	   NOT EXISTS (SELECT * FROM Accounts WHERE Id = @ReceiverId)
	BEGIN
		ROLLBACK
		RAISERROR('Inavlid Accont',16,1)
		RETURN
	END

	IF @Amount<0 OR @Amount> (SELECT Balance FROM Accounts WHERE Id = @SenderId)
	BEGIN
		ROLLBACK
		RAISERROR('Inavalid MoneyAmmount',16,1)
		RETURN
	END

	UPDATE Accounts
	   SET Balance +=@Amount
     WHERE Id = @ReceiverId

	 UPDATE Accounts
	   SET Balance -=@Amount
     WHERE Id = @SenderId

COMMIT

--Problem 06

SELECT * FROM UsersGames
SELECT * FROM UserGameItems
SELECT * FROM Items

CREATE TRIGGER tr_notBuyingItems_With_HigherLevel
ON UserGameItems INSTEAD OF INSERT
AS BEGIN
	IF (SELECT it.MinLevel 
	      FROM inserted AS i
		  JOIN Items AS it ON it.Id = i.ItemId) <= (SELECT ug.Level
													  FROM inserted AS i
													  JOIN UsersGames AS ug ON ug.Id = i.UserGameId)
		BEGIN
			INSERT INTO UserGameItems (ItemId,UserGameId)
			SELECT ItemId,UserGameId
			FROM inserted
		END
END
---
UPDATE UsersGames
   SET Cash +=50000
 WHERE GameId = (SELECT Id FROM Games WHERE [Name] = 'Bali') AND
	   UserId IN (SELECT Id FROM Users WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos'))
   
---
SELECT u.Username,g.[Name],ug.Cash 
  FROM UsersGames AS ug
  JOIN Games AS g ON ug.GameId = g.Id
  JOIN Users AS u ON u.Id = ug.UserId
 WHERE u.Username  IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
   AND g.[Name] = 'Bali'

---
SELECT * FROM Items
SELECT * FROM ItemTypes

CREATE OR ALTER PROCEDURE udf_BuyingItems @Item INT, @Username NVARCHAR(50)
AS
BEGIN TRANSACTION
	DECLARE @PriceItemForByuing MONEY = (SELECT Price
										   FROM Items
										  WHERE Id = @Item)
	DECLARE @CashUsername MONEY= (SELECT Cash
									FROM UsersGames
								   WHERE UserId = (SELECT Id
													 FROM Users
													WHERE Username = @Username)
									 AND GameId = (SELECT Id
													 FROM Games
													WHERE [Name] = 'Bali'))
	DECLARE @user INT = (SELECT Id FROM Users WHERE Id = (SELECT Id
													       FROM Users
													      WHERE Username = @Username))
	DECLARE @itemid INT= (SELECT Id FROM Items WHERE Id = @Item)
	IF @user IS NULL or @itemid IS NULL
		BEGIN
			ROLLBACK
			RAISERROR('Inavalid MoneyAmmount',16,1)
			RETURN
		END

	IF (@CashUsername>=@PriceItemForByuing)
	BEGIN
		UPDATE UsersGames
		   SET Cash -= @PriceItemForByuing
		 WHERE UserId = (SELECT Id
						   FROM Users
						  WHERE Username = @Username)
	END
	ELSE
	BEGIN
		ROLLBACK
		RAISERROR('Inavalid MoneyAmmount',16,1)
		RETURN
	END
COMMIT

DECLARE @startInt INT = 251
WHILE (@startInt <= 299)
BEGIN
	EXEC udf_BuyingItems @startInt, 'baleremuda'
	SET @startInt +=1
END

SELECT u.Username,g.[Name],ug.Cash,it.[Name]
  FROM Users AS u
  JOIN UsersGames AS ug ON ug.UserId = u.Id
  JOIN Games AS g ON g.Id = ug.GameId
  JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
  JOIN Items AS it ON it.Id = ugi.ItemId
 WHERE g.[Name] ='Bali'
 ORDER BY u.Username,it.[Name]

 --Problem 07
-- User Stamat in Safflower game wants to buy some items. He likes all items from Level 11 to 12 as well as all items from Level 19 to 21. As it is a bulk operation you have to use transactions. 
--A transaction is the operation of taking out the cash from the user in the current game as well as adding up the items. 
--Write transactions for each level range. If anything goes wrong turn back the changes inside of the transaction.
--Extract all of Stamat's item names in the given game sorted by name alphabetically.

DECLARE @Table TABLE
(
Id INT PRIMARY KEY IDENTITY(1,1),
[Value] INT NOT NULL
)

INSERT INTO @Table([Value])
(SELECT Id 
  FROM Items
 WHERE MinLevel IN (11,12,19,20,21))

SELECT * FROM  @Table

DECLARE @startingint INT = 1
WHILE @startingint<=(SELECT COUNT(*) FROM @Table)
BEGIN
	EXEC udf_BuyingItems 
	SET @startingint+=1;
END

--Problem 08
--Create a procedure usp_AssignProject(@emloyeeId, @projectID) that assigns projects to an employee.
--If the employee has more than 3 project throw exception and rollback the changes. 
--The exception message must be: "The employee has too many projects!" with Severity = 16, State = 1.

CREATE OR ALTER PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
	DECLARE @NumberOfProjects INT = (SELECT COUNT(*)
									   FROM EmployeesProjects
									  WHERE EmployeeID = @emloyeeId)
	IF @NumberOfProjects >= 3
	BEGIN
		ROLLBACK
		RAISERROR ('The employee has too many projects!',16,1)
		RETURN
	END

	INSERT INTO EmployeesProjects(EmployeeID,ProjectID)
	VALUES
	(@emloyeeId,@projectID)
COMMIT

--Problem 09
--Create a table Deleted_Employees(EmployeeId PK, FirstName, LastName, 
--MiddleName, JobTitle, DepartmentId, Salary) that will hold information 
--about fired (deleted) employees from the Employees table. Add a trigger 
--to Employees table that inserts the corresponding information about 
--the deleted records in Deleted_Employees.

SELECT * FROM Employees
CREATE TABLE Deleted_Employees
(
	EmployeeId  INT PRIMARY KEY,
	FirstName VARCHAR(50)NOT NULL,
	LastName VARCHAR(50)NOT NULL, 
	MiddleName VARCHAR(50)NOT NULL, 
	JobTitle VARCHAR(50)NOT NULL, 
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(DepartmentId), 
	Salary MONEY NOT NULL
)
CREATE OR ALTER TRIGGER tr_InfoFOR_DeletedEmployee
ON Employees FOR DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees
	SELECT EmployeeID,FirstName,LastName,MiddleName,JobTitle,DepartmentID,Salary
	  FROM deleted
	
END

SELECT * FROM Employees
DELETE 
  FROM Employees
 WHERE EmployeeID = 1

DELETE 
  FROM EmployeesProjects
 WHERE EmployeeID = 1

 SELECT * FROM Deleted_Employees