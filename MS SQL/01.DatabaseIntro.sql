CREATE DATABASE [Minions]

USE [Minions]

CREATE TABLE [Minions]
(
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NULL,
	[Age] INT NOT NULL
)

CREATE TABLE [Towns](
[Id] INT PRIMARY KEY,
[Name] NVARCHAR(70) NOT NULL
)

ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL

GO

INSERT INTO [Towns]([Id],[Name])
	VALUES
	(1,'Sofia'),
	(2,'Plovdiv'),
	(3,'Varna')

SELECT * FROM [Towns]


ALTER TABLE [Minions]
ALTER COLUMN [Age] INT

INSERT INTO [Minions]([Id],[Name],[Age],[TownId])
	VALUES
	(1,'Kevin',22, 1),
	(2,'Bob',15, 3),
	(3,'Steward',NULL,2)

	SELECT * FROM [Towns]
	SELECT * FROM [Minions]

TRUNCATE TABLE [Minions]	
SELECT * FROM [Minions]
DROP TABLE [Minions]
DROP TABLE [Towns]

CREATE TABLE [People](
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
[Picture] VARBINARY(MAX),
CHECK (DATALENGTH([Picture]) <= 2000000),
[Height] DECIMAL(3,2),
[Weight] DECIMAL(5,2),
[Gender] CHAR(1) NOT NULL,
CHECK ([Gender] = 'm' OR [Gender] = 'f'),
[Birthday] DATE NOT NULL,
[Biography] NVARCHAR(MAX),
)

INSERT INTO [People] ([Name], [Height], [Weight], [Gender], [Birthday])
	VALUES
	('Pesho', 1.77,75.2,'m', '1998-05-25'),
	('Pesho', 1.77,75.2,'m', '1998-05-25'),
	('Pesho', 1.77,75.2,'m', '1998-05-25'),
	('Pesho', 1.77,75.2,'m', '1998-05-25'),
	('Pesho', 1.77,75.2,'m', '1998-05-25')


	CREATE TABLE [Users](
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY,
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] TIME NOT NULL,
	[IsDeleted] VARCHAR(5) NOT NULL,
	CHECK ([IsDeleted]='true' OR [IsDeleted]='false')
	)

	INSERT INTO [Users] ([Username],[Password],[LastLoginTime],[IsDeleted])
		VALUES
		('Irena','i90007', '05:10:00','true'),
		('Irena','i9007', '05:10:00','true'),
		('Irena','i9007', '05:10:00','true'),
		('Irena','i9007', '05:10:00','true'),
		('Irena','i9007', '05:10:00','true')


		ALTER TABLE [Users]
		DROP CONSTRAINT pk_CompositePK

		ALTER TABLE [Users]
		ADD CONSTRAINT PK_Composite PRIMARY KEY ([Id],[UserName]);

		ALTER TABLE [Users]
		ADD CONSTRAINT CK_If5 CHECK (LEN([Password])>=5); 

		INSERT INTO [Users] ([Username],[Password],[LastLoginTime],[IsDeleted])
		VALUES
		('Irena','07', '05:10:00','true')

		ALTER TABLE [Users]
		ADD CONSTRAINT DF_Time DEFAULT GETDATE() FOR [LastLoginTime]

		INSERT INTO [Users] ([Username],[Password],[IsDeleted])
		VALUES
		('Irena','012dd37','false')

		SELECT * FROM [Users]

		ALTER TABLE [Users]
		DROP CONSTRAINT PK_Composite

		ALTER TABLE [Users]
		ADD CONSTRAINT PK_new PRIMARY KEY ([Id])

		TRUNCATE TABLE [Users]


		ALTER TABLE [Users]
		ADD CONSTRAINT UQ_UserName_Unique UNIQUE ([Username])
		
		ALTER TABLE [Users]
		ADD CONSTRAINT CK_IfLOng CHECK (LEN([Username])>=3)
		
		DROP DATABASE [Movies]
		--new database, 13.homework
		CREATE DATABASE [Movies]
		GO
		USE [Movies]
		GO

		CREATE TABLE [Directors](
		[Id] INT PRIMARY KEY IDENTITY,
		[DirectorName] VARCHAR(50) NOT NULL,
		[Notes] VARCHAR(200)
		)

		CREATE TABLE [Genres](
		[Id] INT PRIMARY KEY IDENTITY,
		[GenreName] VARCHAR(50) NOT NULL,
		[Notes] VARCHAR(200)
		)

		CREATE TABLE [Categories](
		[Id] INT PRIMARY KEY IDENTITY,
		[CategoryName] VARCHAR(50) NOT NULL,
		[Notes] VARCHAR(200)
		)

		CREATE TABLE [Movies](
		[Id] INT PRIMARY KEY IDENTITY,
		[Title] VARCHAR(50) NOT NULL,
		[DirectorId] INT FOREIGN KEY REFERENCES [Directors] ([Id]),
		[CopyrightYear] DATETIME2 NOT NULL,
		[Length] TIME NOT NULL,
		[GenreId] INT FOREIGN KEY REFERENCES [Genres] ([Id]),
		[CategoryId] INT FOREIGN KEY REFERENCES [Categories] ([Id]),
		[Rating] DECIMAL(4,2)NOT NULL,
		[Notes] VARCHAR(200)
		)

		ALTER TABLE[Movies]
		ALTER COLUMN [CopyrightYear] CHAR(4) NOT NULL

		INSERT INTO [Directors] ([DirectorName])
		VALUES
		('Ivan'),
		('1Ivan'),
		('2Ivan'),
		('3Ivan'),
		('4Ivan')

		INSERT INTO [Genres] ([GenreName])
		VALUES
		('dfdf'),
		('1dfdf'),
		('2dfdf'),
		('3dfdf'),
		('4dfdf')

		INSERT INTO [Categories] ([CategoryName])
		VALUES
		('fdf'),
		('fdfd'),
		('hyui'),
		('3oooo'),
		('4vvvv')

		INSERT INTO [Movies] ([Title],[DirectorId],[CopyrightYear],[Length],[GenreId],[CategoryId],[Rating])
		VALUES
		('fil1',2,1950,'5:57',1,2,5),
		('fil1',2,1950,'5:57',1,2,5.2),
		('fil1',2,1950,'5:57',1,2,5.27),
		('fil1',2,1950,'5:57',1,2,10),
		('fil1',2,1950,'5:57',1,2,10.3)

-- New Database CarRental, 14.

CREATE DATABASE [CarRental]

USE [CarRental]

CREATE TABLE [Categories] (
Id INT PRIMARY KEY IDENTITY,
CategoryName VARCHAR(50) NOT NULL,
DailyRate DECIMAL (3,2) NOT NULL,
WeeklyRate DECIMAL (3,2) NOT NULL,
MonthlyRate DECIMAL (3,2) NOT NULL,
WeekendRate DECIMAL (3,2) NOT NULL
)

CREATETABLE[Cars]([Id]INTPRIMARYKEYIDENTITY,[CategoryType]INTFOREIGNKEYREFERENCES[Categories]([Id])
)

--16. SoftUniDataBAse
CREATE DATABASE SoftUni
GO
USE SoftUni
GO



CREATE TABLE Towns (
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL)

CREATE TABLE Adresses(
Id INT PRIMARY KEY IDENTITY,
AddressText VARCHAR(200) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns (Id)
)

CREATE TABLE Departments (
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
MiddleName VARCHAR(50),
LastName VARCHAR(50) NOT NULL,
JobTitle VARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments (Id),
HireDate DATE NOT NULL,
Salary DECIMAL (8,2),
AddressId INT FOREIGN KEY REFERENCES Adresses (Id)
)

BACKUP DATABASE SoftUni
TO DISK = 'C:\Users\schhh\Desktop\SoftUni\softuni-backup.bak'


BACKUP DATABASE SoftUni
TO DISK = 'F:\softuni-backup2.bak'

DROP DATABASE SoftUni

RESTORE DATABASE SoftUni
FROM DISK = 'F:\softuni-backup2.bak'

INSERT INTO Towns ([Name])
VALUES
('Sofia'), 
('Plovdiv'), 
('Varna'), 
('Burgas')

INSERTINTODepartments([Name])
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('SoftwareDevelopment'),
('QualityAssurance')

INSERT INTO Employees ([FirstName],[MiddleName],[LastName],[JobTitle],
[DepartmentId],[HireDate],[Salary])
VALUES
('Ivan' ,'Ivanov', 'Ivanov','.NET Developer',4 ,'01/02/2013','3500.00')

SELECT * FROM [Employees]

SELECT * FROM [Towns]
ORDER BY Id DESC

SELECT [FirstName], [MiddleName] FROM Employees

UPDATE Employees
SET Salary *= 1.1;

SELECT Salary FROM Employees
