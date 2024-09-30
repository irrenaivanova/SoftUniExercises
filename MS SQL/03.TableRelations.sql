SELECT * FROM Mountains

SELECT * FROM Peaks


SELECT m.MountainRange AS 'Name'
	  ,p.PeakName
      ,p.Elevation 
FROM Mountains AS m
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE 
	   m.MountainRange = 'Rila'
ORDER BY 
	   p.Elevation DESC

SELECT m.MountainRange AS 'Name'
	  ,p.PeakName
      ,p.Elevation
	  ,c.CountryCode
FROM Mountains AS m
JOIN Peaks AS p ON p.MountainId = m.Id
JOIN MountainsCountries AS c ON m.Id = c.MountainId
WHERE 
	   m.MountainRange = 'Rila'
ORDER BY 
	   p.Elevation DESC


--Exercises
--Ex.1
CREATE DATABASE EntityRelations
DROP TABLE Passports
DROP TABLE Persons

CREATE TABLE Passports(
PassportID INT PRIMARY KEY, 
PassportNumber VARCHAR(8) NOT NULL
)

CREATE TABLE Persons(
PersonID INT PRIMARY KEY IDENTITY (1,1),
FirstName VARCHAR(30) NOT NULL,
Salary DECIMAL(12,2) NOT NULL,
PassportID INT FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE NOT NULL
--PassportID INT CONSTRAINT CU_Passport UNIQUE,
--CONSTRAINT FK_PassportPerson FOREIGN KEY(PassportID) REFERENCES Passports(PassportID)
)

INSERt INTO Passports (PassportID,PassportNumber)
VALUES
(101,'N34FG21B'),
(102,'K65LO4R7'),
(103,'ZE657QP2')


INSERT INTO Persons (FirstName,Salary,PassportId)  
VALUES 
('Roberto', 43300, 102),
('Tom', 56100,103),
('Yana',60200,101)

SELECT * FROM Persons

--EX.2
DROP TABLE Models
DROP TABLE Manufacturers
CREATE TABLE Manufacturers
(
ManufacturerID INT PRIMARY KEY IDENTITY, 
[Name] VARCHAR(50) NOT NULL,
EstablishedOn DATE NOT NULL
)


CREATE TABLE Models
(
ModelID INT PRIMARY KEY IDENTITY(101,1),
[Name] VARCHAR(50) NOT NULL,
ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers([Name],EstablishedOn)
VALUES
('BMW',CONVERT(DATE,'07/03/1916',101)),
('Tesla',CONVERT(DATE,'01/01/2003',101)),
('Lada',CONVERT(DATE,'01/05/1966',101))

INSERT INTO Models ([Name],ManufacturerID)
	 VALUES
		('X1',1),
		('i6',1),
		('Model S',2),
		('Model X',2),
		('Model 3',2),
		('Nova',3)

--Ex.3
CREATE TABLE Students
(
StudentsID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Exams
(
ExamID INT PRIMARY KEY IDENTITY (101,1),
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams
(
StudentID INT NOT NULL FOREIGN KEY REFERENCES Students (StudentsID),
ExamID INT NOT NULL FOREIGN KEY REFERENCES Exams(ExamID)
CONSTRAINT PK_StudentID_ExamID PRIMARY KEY (StudentID,ExamID)
)

--EX.4
CREATE TABLE Teachers
(
TeacherID INT PRIMARY KEY IDENTITY (101,1),
[Name] VARCHAR(50) NOT NULL, 
ManagerID INT FOREIGN KEY REFERENCES Teachers (TeacherID)
)

--EX.5
CREATE TABLE ItemTypes
(
ItemTypeID INT PRIMARY KEY ,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items
(
ItemID INT PRIMARY KEY ,
[Name] VARCHAR(50) NOT NULL,
[ItemTypeID] INT FOREIGN KEY REFERENCES ItemTypes([ItemTypeID])
)
CREATE TABLE Cities
(
CityID INT PRIMARY KEY ,
[Name] VARCHAR(50)  NOT NULL,
)

CREATE TABLE Customers
(
CustomerID INT PRIMARY KEY ,
[Name] VARCHAR(50) NOT NULL,
Birthday DATE,
CityID INT FOREIGN KEY REFERENCES Cities(CityID) 
) 

CREATE TABLE Orders
(
OrderID INT PRIMARY KEY ,
CostumerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems
(
OrderID INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderID),
ItemID INT NOT NULL FOREIGN KEY REFERENCES Items(ItemID)
PRIMARY KEY (OrderID,ItemID)
)

DROP TABLE Orders
DROP TABLE Customers
DROP TABLE Cities
DROP TABLE Items
DROP TABLE OrderItems
DROP TABLE ItemTypes

--EX.6
CREATE DATABASE University

CREATE TABLE Majors
(
MajorID INT PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Subjects
(
SubjectID INT PRIMARY KEY,
[SubjectName] VARCHAR(50) NOT NULL
)


CREATE TABLE [Students]
(
StudentID INT PRIMARY KEY,
StudentNumber VARCHAR(20) NOT NULL,
StudentName VARCHAR(50) NOT NULL,
MajorID INT NOT NULL FOREIGN KEY REFERENCES Majors(MajorID) 
)

CREATE TABLE Agenda
(
StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
PRIMARY KEY (StudentID,SubjectID)
)

CREATE TABLE Payments
(
PaymentID INT PRIMARY KEY,
PaymentDate DATE,
PaymentAmount DECIMAL(10,2) NOT NULL,
StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)


--EX.9
SELECT * FROM Peaks
SELECT * FROM Mountains

SELECT MountainRange,PeakName,Elevation
FROM Mountains AS m
JOIN Peaks AS p ON p.MountainID = m.Id AND m.MountainRange = 'Rila'  
ORDER BY Elevation DESC

