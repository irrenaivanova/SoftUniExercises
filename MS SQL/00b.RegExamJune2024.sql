CREATE DATABASE LibraryDb
DROP DATABASE LibraryDb 
--Problem 1


CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Contacts
(
	Id INT PRIMARY KEY IDENTITY,
	Email NVARCHAR(100),
	PhoneNumber NVARCHAR(20),
	PostAddress NVARCHAR(200), 
	Website NVARCHAR(50) 
)

CREATE TABLE Authors
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	ContactId INT NOT NULL FOREIGN KEY REFERENCES Contacts(Id)
)

CREATE TABLE Libraries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	ContactId INT NOT NULL FOREIGN KEY REFERENCES Contacts(Id)
)

CREATE TABLE Books
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	YearPublished INT NOT NULL,
	ISBN NVARCHAR(13) UNIQUE NOT NULL,
	AuthorId INT NOT NULL FOREIGN KEY REFERENCES Authors(Id),
	GenreId INT NOT NULL FOREIGN KEY REFERENCES Genres(Id)
)

CREATE TABLE LibrariesBooks
(
	LibraryId INT NOT NULL FOREIGN KEY REFERENCES Libraries(Id),
	BookId INT NOT NULL FOREIGN KEY REFERENCES Books(Id)
	PRIMARY KEY (LibraryId,BookId)
)


--Problem 2
INSERT INTO Contacts 
VALUES
(NULL,NULL,NULL,NULL),
(NULL,NULL,NULL,NULL),
('stephen.king@example.com','+4445556666','15 Fiction Ave, Bangor, ME','www.stephenking.com'),
('suzanne.collins@example.com',	'+7778889999',	'10 Mockingbird Ln, NY, NY',	'www.suzannecollins.com')



INSERT INTO Authors
VALUES
('George Orwell',	21),
('Aldous Huxley',	22),
('Stephen King',	23),
('Suzanne Collins',	24)

INSERT INTO Books
VALUES
('1984',	1949,	'9780451524935',	16	,2),
('Animal Farm'	,1945,	'9780451526342',	16	,2),
('Brave New World',	1932,	'9780060850524',	17,	2),
('The Doors of Perception',	1954,	'9780060850531',	17,	2),
('The Shining',	1977,	'9780307743657',	18,	9),
('It',	1986,	'9781501142970'	,18,	9),
('The Hunger Games'	,2008,	'9780439023481',	19,	7),
('Catching Fire',	2009	,'9780439023498',	19,	7),
('Mockingjay',	2010,'9780439023511',	19	,7)


INSERT INTO LibrariesBooks
VALUES
(1	,36),
(1,	37),
(2	,38),
(2,	39),
(3	,40),
(3,41),
(4,	42),
(4 ,  43),
(5  , 44)


--Problem 3
UPDATE c
   SET c.Website = CONCAT_WS('.','www',LOWER(REPLACE(a.Name,' ','')),'com')
  FROM Contacts AS c
  JOIN Authors AS a ON a.ContactId = c.Id
 WHERE c.Website IS NULL 

-- Problem 4
 
DELETE FROM LibrariesBooks
 WHERE BookId = (SELECT b.Id 
				   FROM Books AS b
				   JOIN Authors AS a ON a.Id = b.AuthorId
				  WHERE b.AuthorId = (SELECT Id From Authors WHERE [Name] = 'Alex Michaelides' ))

DELETE FROM Books
 WHERE AuthorId = (SELECT Id From Authors WHERE [Name] = 'Alex Michaelides' )

DELETE FROM Authors
 WHERE [Name] = 'Alex Michaelides'


 --Problem 5
 SELECT Title AS [Book Title],ISBN,YearPublished AS YearReleased 
   FROM Books
  ORDER BY YearReleased DESC, [Book Title] ASC

--Problem 6
SELECT b.Id, Title, ISBN, g.Name AS Genre
  FROM Books AS b
  JOIN Genres AS g ON g.Id = b.GenreId
 WHERE g.Name  IN ('Biography', 'Historical Fiction') 
 ORDER BY g.Name,Title

 --Problem 7
 WITH CTE_Books AS
 (SELECT l.Name AS Library, g.Name, co.Email
   FROM Libraries AS l
   LEFT JOIN LibrariesBooks AS lb ON lb.LibraryId = l.Id
   LEFT JOIN Books AS b ON b.Id = lb.BookId
   LEFT JOIN Genres AS g ON g.Id = b.GenreId 
   LEFT JOIN Contacts AS co ON co.Id = l.ContactId)

SELECT DISTINCT [Library],Email
  FROM CTE_Books
 WHERE Library NOT IN (SELECT [Library] FROM  CTE_Books WHERE [Name] = 'Mystery')
 ORDER BY [Library]

 --Problem 8
 SELECT TOP (3) Title, YearPublished AS [Year], g.Name as Genre
   FROM Books AS b
   LEFT JOIN Genres AS g ON b.GenreId = g.Id
  WHERE  (YearPublished > 2000 AND Title LIKE '%a%') OR (YearPublished<1950 AND g.Name LIKE'%Fantasy%')
  ORDER BY Title,[Year] DESC

--Problem 9
SELECT a.Name AS Author, Email, PostAddress AS [Address]
  FROM Authors AS a
  JOIN Contacts AS c ON a.ContactId = c.Id
 WHERE c.PostAddress LIKE '%UK'
 ORDER BY a.Name

-- Problem 10
SELECT a.Name AS Author,b.Title,l.[Name] AS [Library],co.PostAddress AS [Library Address] 
  FROM LibrariesBooks AS lb 
  LEFT JOIN Books AS b ON b.Id = lb.BookId
  LEFT JOIN Libraries AS  l ON l.Id = lb.LibraryId
  LEFT JOIN Authors AS a ON a.ID = b.AuthorId
  LEFT JOIN Genres AS g ON g.Id = b.GenreId
  LEFT JOIN Contacts AS co ON co.Id = l.ContactId
  WHERE g.Name = 'Fiction' AND co.PostAddress LIKE '%Denver%' 
  ORDER BY b.Title

  SELECT * FROM Books ORDER BY Title
  SELECT * FROM Genres

  --Problem 11
CREATE OR ALTER FUNCTION dbo.udf_AuthorsWithBooks(@name NVARCHAR(100))
RETURNS INT AS
BEGIN
	DECLARE @Result INT = 
	(SELECT COUNT (b.Title)   
	  FROM LibrariesBooks AS lb
	  LEFT JOIN Books AS b ON lb.BookId = b.Id
	  LEFT JOIN Authors AS a ON a.Id = b.AuthorId
	 WHERE a.Name =@name)
	RETURN @Result
END

SELECT dbo.udf_AuthorsWithBooks('J.K. Rowling')

--Problem 12
--CREATE OR ALTER PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
--AS
--BEGIN TRANSACTION
--	DECLARE @DepIdEmployee INT = (SELECT TOP(1)DepartmentId FROM Employees WHERE Id = @EmployeeId)
--	DECLARE @DepIdReport INT = (SELECT TOP (1) c.DepartmentId 
--								  FROM Reports AS r 
--								  LEFT JOIN Categories AS c ON c.Id= r.CategoryId
--								 WHERE r.Id = @ReportId)
--	IF (@DepIdEmployee<>@DepIdReport)
--	BEGIN
--		ROLLBACK
--		RAISERROR ('Employee doesn''t belong to the appropriate department!',16,1)
--		RETURN
--	END
--	UPDATE Reports
--	   SET EmployeeId = @EmployeeId 
--     WHERE Id =@ReportId 
--COMMIT

--EXEC usp_AssignEmployeeToReport 30, 1


CREATE OR ALTER PROCEDURE usp_SearchByGenre(@genreName NVARCHAR(30))
AS
BEGIN TRANSACTION
	SELECT Title, YearPublished AS [Year], ISBN,a.Name AS Author, g.Name AS Genre
	  FROM Books AS b
	  LEFT JOIN Genres AS g ON g.Id = b.GenreId
	  LEFT JOIN Authors AS a ON a.Id = b.AuthorId
	  WHERE g.Name = @genreName
	  ORDER BY Title
COMMIT

EXEC usp_SearchByGenre 'Fantasy'