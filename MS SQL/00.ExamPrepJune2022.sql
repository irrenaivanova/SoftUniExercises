CREATE DATABASE Zoo
--Problem 01
CREATE TABLE Owners
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
[Address] VARCHAR(50) 
)

CREATE TABLE AnimalTypes
(
Id INT PRIMARY KEY IDENTITY,
AnimalType VARCHAR(30) NOT NULL,
)

CREATE TABLE Cages
(
Id INT PRIMARY KEY IDENTITY,
AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE Animals
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
BirthDate DATE NOT NULL,
OwnerId INT FOREIGN KEY REFERENCES Owners(Id), 
AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE AnimalsCages
(
CageId INT FOREIGN KEY REFERENCES Cages(Id),
AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
PRIMARY KEY (CageId,AnimalId) 
)

CREATE TABLE VolunteersDepartments
(
Id INT PRIMARY KEY IDENTITY,
DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
[Address] VARCHAR(50),
AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL
)


--Problem 02
INSERT INTO Volunteers
VALUES
('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
('Dimitur Stoev','0877564223',	null,42,4),
('Kalina Evtimova',	'0896321112','Silistra, 21 Breza str.',	9,	7),
('Stoyan Tomov',	'0898564100',	'Montana, 1 Bor str.'	,18,8),
('Boryana Mileva',	'0888112233',	null,	31	,5)

INSERT INTO Animals
VALUES
('Giraffe',	'2018-09-21',	21,	1),
('Harpy Eagle',	'2015-04-17',	15,	3),
('Hamadryas Baboon',	'2017-11-02',	null,	1),
('Tuatara',	'2021-06-30',	2	,4)

--Problem 03
SELECT *FROM Owners

UPDATE Animals
SET OwnerID = (SELECT ID FROM Owners WHERE [Name] = 'Kaloqn Stoqnov')
WHERE OwnerId IS NULL

--Problem 04
DELETE FROM Volunteers
WHERE DepartmentId = (SELECT Id FROM VolunteersDepartments WHERE DepartmentName ='Education program assistant')

DELETE FROM VolunteersDepartments
WHERE DepartmentName = 'Education program assistant'

--Problem 05
DROP DATABASE Zoo
SELECT [Name],PhoneNumber, [Address], AnimalId, DepartmentId 
  FROM Volunteers
 ORDER BY [Name], AnimalId DESC, DepartmentId

--Problem 06
SELECT a.[Name],t.AnimalType,FORMAT(a.BirthDate,'dd.MM.yyyy') AS BirthDate
  FROM Animals AS a
  JOIN AnimalTypes AS t ON t.Id = a.AnimalTypeId
 ORDER BY a.[Name] ASC 

--Problem 07
SELECT TOP(5)
	   o.[Name] AS [Owner],Count(*) AS [CountOfAnimals] 
  FROM Animals AS a
  JOIN Owners AS o ON o.Id= a.OwnerId  
 GROUP BY o.[Name]
 ORDER BY [CountOfAnimals] DESC,[Owner]

-- Problem 08
SELECT CONCAT_WS('-',o.[Name],a.[Name]) AS OwnersAnimals,
       o.PhoneNumber,
	   c.Id
  FROM Animals AS a
  JOIN AnimalTypes AS t ON a.AnimalTypeId = t.Id
  JOIN Owners AS o ON a.OwnerId = o.Id
  JOIN AnimalsCages AS ac ON a.Id = ac.AnimalId
  JOIN Cages AS c ON c.Id = ac.CageId
 WHERE t.AnimalType = 'Mammals' 
 ORDER BY o.[Name], a.[Name] DESC

 --Problem 09
 SELECT v.Name,v.PhoneNumber, LTRIM(SUBSTRING(v.[Address],CHARINDEX(', ',v.[Address])+1,LEN(v.[Address]))) AS [Address]
   FROM Volunteers AS v
   JOIN VolunteersDepartments  AS d ON v.DepartmentId = d.Id
  WHERE v.Address LIKE '%Sofia%'
    AND d.DepartmentName = 'Education program assistant'
  ORDER BY v.Name

-- Problem 10
SELECT a.[Name],DATEPART(YEAR,a.BirthDate) AS BirthYear,t.AnimalType
  FROM Animals AS a
  JOIN AnimalTypes AS t ON a.AnimalTypeId = t.Id
 WHERE a.OwnerId IS NULL
   AND t.AnimalType NOT IN ('Birds')
   AND DATEDIFF(YEAR,a.BirthDate,'2022/01/01') <=5
 ORDER BY a.Name

 --Problem 11
 CREATE OR ALTER FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
 RETURNS INT AS
 BEGIN
	DECLARE @Result INT
		SET @Result = ( SELECT COUNT(*)
						  FROM Volunteers AS v
						  JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
						 WHERE vd.DepartmentName =@VolunteersDepartment)
	RETURN @Result
 END

 SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')
 SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')

 --Problem 12
CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
		 SELECT a.[Name], 
				CASE
					WHEN o.[Name] IS NULL THEN 'For adoption'
					ELSE o.[Name]
				END AS OwnersName
		   FROM Animals AS a
	  LEFT JOIN Owners AS o ON a.OwnerId = o.Id
	      WHERE a.Name = @AnimalName
END

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
EXEC usp_AnimalsWithOwnersOrNot 'Hippo'