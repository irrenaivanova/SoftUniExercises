--Problem 01
WITH CTE_EmailProvider AS
(SELECT Username,
	   SUBSTRING(Email,CHARINDEX('@',Email)+1,LEN(Email)) AS [Email Provider]
  FROM Users
)

SELECT [Email Provider],COUNT(*) AS [Number Of Users]
  FROM CTE_EmailProvider
 GROUP BY [Email Provider]
 ORDER by COUNT(*) DESC, [Email Provider]

 --Problem 02
 SELECT g.[Name],gt.[Name],u.Username,ug.[Level],ug.Cash,ch.Name
   FROM Users AS u
   LEFT JOIN UsersGames AS ug ON ug.UserId = u.Id
   LEFT JOIN Games AS g ON g.Id = ug.GameId
   LEFT JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
   LEFT JOIN Characters AS ch ON ch.Id = ug.CharacterId
  ORDER BY ug.[Level] DESC,u.Username,g.[Name]

--Problem 03
SELECT u.Username,g.[Name] AS Game,
	   Count(it.[Name]) AS [Items Count],
	   SUM(it.Price) AS [Items Price] 
  FROM Users AS u
  LEFT JOIN UsersGames AS ug ON  ug.UserId= u.Id
  LEFT JOIN Games AS g ON g.Id = ug.GameId
  LEFT JOIN UserGameItems AS ugi ON ugi.UserGameId= ug.Id
  LEFT JOIN Items AS it ON ugi.ItemId = it.Id
 GROUP BY u.Username,g.[Name]
HAVING Count(it.[Name])>=10 
 ORDER BY [Items Count] DESC,[Items Price] DESC,u.Username

--Problem 04

SELECT u.Username, g.[Name] AS [Game],
	   ch.[Name] AS [Character],
	   st.Strength,st.Defence,st.Speed,st.Mind,st.Luck,
	   it.[Name] AS Item,it.Price,
	   st2.Strength,st2.Defence,st2.Speed,st2.Mind,st2.Luck,
	   gt.[Name] AS [GameTypeName],
	   st3.Strength,st3.Defence,st3.Speed,st3.Mind,st3.Luck
  FROM Users AS u
  LEFT JOIN UsersGames AS ug ON ug.UserId = u.Id
  LEFT JOIN Games AS g ON g.Id = ug.GameId
  LEFT JOIN Characters AS ch ON ch.Id= ug.CharacterId
  LEFT JOIN [Statistics] AS st ON st.Id = ch.StatisticId
  LEFT JOIN UserGameItems AS ugi ON ugi.UserGameId= ug.Id
  LEFT JOIN Items AS it ON ugi.ItemId = it.Id
  LEFT JOIN [Statistics] AS st2 ON st2.Id= it.StatisticId 
  LEFT JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
  LEFT JOIN [Statistics] AS st3 ON st3.Id = gt.BonusStatsId 
 ORDER BY u.Username,g.[Name]

 ---
 SELECT u.Username, g.[Name] AS [Game],
	   MAX(ch.[Name]) AS [Character],
	   MAX(st.Strength)+SUM(st2.Strength)+MAX(st3.Strength) AS Strength,
	   MAX(st.Defence)+SUM(st2.Defence)+MAX(st3.Defence) AS Defence,
	   MAX(st.Speed)+SUM(st2.Speed)+MAX(st3.Speed) AS Speed,
	   MAX(st.Mind)+SUM(st2.Mind)+MAX(st3.Mind) AS Mind,
	   MAX(st.Luck)+SUM(st2.Luck)+MAX(st3.Luck) AS Luck
  FROM Users AS u
  LEFT JOIN UsersGames AS ug ON ug.UserId = u.Id
  LEFT JOIN Games AS g ON g.Id = ug.GameId
  LEFT JOIN Characters AS ch ON ch.Id= ug.CharacterId
  LEFT JOIN [Statistics] AS st ON st.Id = ch.StatisticId
  LEFT JOIN UserGameItems AS ugi ON ugi.UserGameId= ug.Id
  LEFT JOIN Items AS it ON ugi.ItemId = it.Id
  LEFT JOIN [Statistics] AS st2 ON st2.Id= it.StatisticId 
  LEFT JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
  LEFT JOIN [Statistics] AS st3 ON st3.Id = gt.BonusStatsId 
 GROUP BY u.Username,g.[Name]
 ORDER BY Strength DESC,Defence DESC,Speed DESC,Mind DESC,Luck DESC

 --Problem 05

 WITH av AS
 (SELECT AVG(st.Speed) AS AvgSpeed,
	    AVG(st.Luck) AS AvgLuck,
		AVG(st.Mind) AS AvgMind
   FROM Items AS it
   LEFT JOIN [Statistics] AS st ON st.Id = it.StatisticId)

 SELECT it.[Name], it.Price,it.MinLevel,
		st.Strength, st.Defence, 
		st.Speed,st.Luck,st.Mind 
   FROM Items AS it
   LEFT JOIN [Statistics] AS st ON st.Id = it.StatisticId
  WHERE st.Speed > (SELECT AvgSpeed FROM av)AND
		st.Luck > (SELECT AvgLuck FROM av) AND
		st.Mind > (SELECT AvgMind FROM av)
  ORDER BY it.[Name]

  --Problem 06

SELECT it.[Name] AS Item,it.Price,it.MinLevel,gt.[Name] AS [Forbidden Game Type]
  FROM Items AS it
  LEFT JOIN GameTypeForbiddenItems AS gtf ON gtf.ItemId = it.Id
  LEFT JOIN GameTypes AS gt ON gtf.GameTypeId = gt.Id
 ORDER BY gt.[Name] DESC,it.[Name]

 --Problem 07
-- User Alex is in the shop of the game "Edinburgh" and 
-- she wants to buy some items. She likes Blackguard, 
-- Bottomless Potion of Amplification, Eye of Etlich (Diablo III),
-- Gem of Efficacious Toxin, Golden Gorget of Leoric and Hellfire Amulet.
-- Buy the items. You should add the data in the right tables.
-- Get the money for the items from the user in column Cash.
--Select all users in the current game with their items.
--Display username, game name, cash and item name. Sort the result by item name.
GO
CREATE OR ALTER PROC udf_ByuingItems (@UserName NVARCHAR(50),@ItemName NVARCHAR(50),@GameName NVARCHAR(50))
AS
BEGIN TRANSACTION
	DECLARE @IdGame INT = (SELECT Id FROM Games WHERE [Name] = @GameName)
	DECLARE @IdUser INT = (SELECT Id FROM Users WHERE [Username] = @UserName)
	DECLARE @IdUserGames INT = (SELECT Id FROM UsersGames WHERE UserId = @IdUser AND GameId = @IdGame)
	DECLARE @PriceItem MONEY = (SELECT Price FROM Items WHERE [Name] = @ItemName)

	IF @IdGame IS NULL OR @IdUser IS NULL OR @IdUserGames IS NULL OR @PriceItem IS NULL
	BEGIN
		ROLLBACK
		RAISERROR ('Invalid input',16,1)
		RETURN
	END

	DECLARE @CashForTheGame MONEY = (SELECT Cash FROM UsersGames WHERE Id = @IdUserGames)

	IF @PriceItem > @CashForTheGame
	BEGIN
		ROLLBACK
		RAISERROR ('Insufficient cash',16,1)
		RETURN
	END

	DECLARE @ItemId INT = (SELECT Id FROM Items WHERE [Name] = @ItemName)
	
	IF EXISTS(SELECT ItemId FROM UserGameItems WHERE ItemId = @ItemId AND UserGameId = @IdUserGames)
	BEGIN
		ROLLBACK
		RAISERROR ('The item is already bought',16,1)
		RETURN
	END
	
	INSERT INTO UserGameItems(ItemId,UserGameId)
	VALUES (@ItemId,@IdUserGames)
	SET @CashForTheGame -=@PriceItem
COMMIT

DECLARE @ItemsForBuying TABLE
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Items NVARCHAR(50) NOT NULL
)

INSERT INTO @ItemsForBuying (Items)
VALUES 
('Blackguard'),
('Bottomless Potion of Amplification'), 
('Eye of Etlich (Diablo III)'), 
('Gem of Efficacious Toxin'), 
('Golden Gorget of Leoric'),
('Hellfire Amulet')

SELECT * FROM @ItemsForBuying

DECLARE @int INT = 1
DECLARE @end INT = (SELECT COUNT(*) FROM @ItemsForBuying)

WHILE @int <= @end
BEGIN
	DECLARE @Item NVARCHAR(50) = (SELECT Items FROM @ItemsForBuying WHERE Id = @int)
	EXEC udf_ByuingItems 'Alex',@Item,'Edinburgh'
	SET @int+=1
END
---
SELECT u.Username,g.[Name],ug.Cash,it.[Name] AS [Item Name]
  FROM Users AS u
  LEFT JOIN UsersGames AS ug ON ug.UserId = u.Id
  LEFT JOIN Games AS g ON g.Id = ug.GameId
  LEFT JOIN UserGameItems AS ugit ON ugit.UserGameId = ug.Id
  LEFT JOIN Items AS it ON it.Id= ugit.ItemId
 WHERE g.[Name] = 'Edinburgh' AND u.Username = 'Alex'
 ORDER BY it.[Name]


 --Problem 08
 SELECT p.PeakName,m.MountainRange,p.Elevation
   FROM Peaks AS p
   LEFT JOIN Mountains AS m ON m.Id = p.MountainId
  ORDER BY p.Elevation DESC,p.PeakName

 
  --Problem 09
  SELECT PeakName,m.MountainRange AS Mountain,c.CountryName,co.ContinentName
   FROM Peaks AS p
   LEFT JOIN Mountains AS m ON m.Id = p.MountainId
   LEFT JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
   LEFT JOIN Countries AS c ON c.CountryCode = mc.CountryCode
   LEFT JOIN Continents AS co ON co.ContinentCode = c.ContinentCode
  ORDER BY p.PeakName,c.CountryName

SELECT * FROm Peaks

--Problem 10
WITH CTE_Country AS
(SELECT c.CountryName,c.ContinentCode,
	   CASE 
	   WHEN Count(r.RiverName) IS NULL THEN 0
	   ELSE Count(r.RiverName) 
	   END AS RiversCount,
	   CASE
	   WHEN SUM(r.Length) IS NULL THEN 0
	   ELSE SUM(r.Length)
	   END AS TotalLength
  FROM Countries AS c 
  LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
  LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
 GROUP BY c.CountryName,c.ContinentCode)


SELECT ct.CountryName,co.ContinentName,ct.RiversCount, ct.TotalLength
  FROM CTE_Country AS ct
  LEFT JOIN Continents AS co ON co.ContinentCode = ct.ContinentCode
 ORDER BY RiversCount DESC, TotalLength DESC,ct.CountryName

 --Problem 11
SELECT c.CurrencyCode,
	   c.[Description] AS Currency, 
	   Count(co.CountryName) AS NumberOfCountries
  FROM Currencies AS c
  LEFT JOIN Countries AS co ON co.CurrencyCode = c.CurrencyCode
 GROUP BY c.CurrencyCode, c.[Description]
 ORDER BY NumberOfCountries DESC,Currency

 --Problem 12
SELECT co.ContinentName,
	   SUM (CONVERT (BIGINT,c.AreaInSqKm)) AS CountriesArea,
	   SUM (CONVERT (BIGINT,c.[Population])) AS CountriesPopulation 
  FROM Continents AS co
  LEFT JOIN Countries AS c ON c.ContinentCode = co.ContinentCode
 GROUP BY co.ContinentName
 ORDER BY CountriesPopulation DESC

 
 --Problem 13
 CREATE TABLE Monasteries
 (
	 Id INT PRIMARY KEY IDENTITY, 
	 [Name] VARCHAR(50) NOT NULL, 
	 CountryCode CHAR(2) NOT NULL FOREIGN KEY REFERENCES Countries(CountryCode)
 )

ALTER TABLE Countries
ADD IsDeleted BIT NOT NULL DEFAULT 0

UPDATE Countries
   SET IsDeleted = 1
 WHERE CountryCode IN (SELECT CountryCode
						 FROM CountriesRivers
						GROUP BY CountryCode
					   HAVING COUNT(RiverId)>=3)

SELECT m.[Name] AS Monastery, c.CountryName AS Country
  FROM Monasteries AS m
  LEFT JOIN Countries AS c ON m.CountryCode = c.CountryCode 
 WHERE c.IsDeleted = 0
 ORDER BY Monastery


--
SELECT CountryCode,COUNT(RiverId)
  FROM CountriesRivers
 GROUP BY CountryCode
HAVING COUNT(RiverId)>=3
--

--Problem 14

SELECT *
  FROM Countries
WHERE CountryName = 'Burma'

UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName ='Myanmar'

INSERT INTO Monasteries ([Name],CountryCode)
VALUES
('Hanga Abbey',(SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania')),
('Myin-Tin-Daik',(SELECT CountryCode FROM Countries WHERE CountryName = 'Burma'))


SELECT co.ContinentName,sub.CountryName,sub.MonasteriesCount
  FROM Continents AS co
  JOIN (SELECT c.ContinentCode,CountryName,COUNT(m.Id)  AS MonasteriesCount
		  FROM Countries AS c
	      LEFT JOIN Monasteries AS m ON c.CountryCode = m.CountryCode
		 WHERE IsDeleted = 0   
		 GROUP BY c.CountryName,c.ContinentCode) AS sub ON sub.ContinentCode = co.ContinentCode
 ORDER BY sub.MonasteriesCount DESC,sub.CountryName



