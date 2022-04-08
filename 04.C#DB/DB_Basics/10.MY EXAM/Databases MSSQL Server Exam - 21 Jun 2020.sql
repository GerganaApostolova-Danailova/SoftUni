CREATE DATABASE TripService


--1.DDL

CREATE TABLE Cities (
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(20) NOT NULL,
CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels (
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(30) NOT NULL,
CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
EmployeeCount INT NOT NULL,
BaseRate DECIMAL(6,2)
)

CREATE TABLE Rooms (
Id INT PRIMARY KEY IDENTITY,
Price DECIMAL (15,2) NOT NULL,
[Type] NVARCHAR(20) NOT NULL,
Beds INT NOT NULL,
HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips (
Id INT PRIMARY KEY IDENTITY,
RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
BookDate DATE NOT NULL,
ArrivalDate DATE NOT NULL,
ReturnDate DATE NOT NULL,
CancelDate DATE,
CONSTRAINT CHK_DateBeforeArrivalDate CHECK(BookDate < ArrivalDate),
CONSTRAINT CHK_DateBeforeReturnDate CHECK(ArrivalDate < ReturnDate),
)

CREATE TABLE Accounts (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(20),
LastName NVARCHAR(50) NOT NULL,
CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
BirthDate DATE NOT NULL,
Email VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE AccountsTrips (
AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
Luggage INT CHECK(Luggage >= 0) NOT NULL,
PRIMARY KEY (AccountId,TripId)
)

--02. Insert 

INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email) VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate) VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

--03. Update

UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN (5,7,9)

-- 4. Delete

--Delete all of Account ID 47’s account’s trips from the mapping table.

DELETE FROM AccountsTrips
WHERE AccountId = 47

-- 5. EEE-Mails
--Select accounts whose emails start with the letter “e”. 
--Select their first and last name, 
--their birthdate in the format "MM-dd-yyyy", and their city name.
--Order them by city name (ascending)

SELECT a.FirstName, a.LastName, 
       FORMAT(a.BirthDate,'MM-dd-yyyy') AS [BirthDate],
	   c.Name AS [Hometown],
	   a.Email
  FROM Accounts AS a
JOIN Cities AS c
ON a.CityId = c.Id
WHERE a.Email LIKE 'e%'
ORDER BY c.Name

--06. City Statistics 

--Select all cities with the count of hotels in them. 
--Order them by the hotel count (descending), then by city name. 
--Do not include cities, which have no hotels in them.
--Examples
--City	Hotels
--Belfast	11
--Cardiff	11
--Chelyabinsk	11
--Phoenix	11
--San Francisco	11
--Seattle	11
--Veliko Tarnovo	11
--Houston	10

SELECT c.Name, COUNT(h.Id) AS [Hotels] FROM Cities AS c
JOIN Hotels AS h
ON c.Id = h.CityId
GROUP BY c.Name
ORDER BY COUNT(h.Id) DESC, c.Name


-- 07. Longest and Shortest Trips 

--Find the longest and shortest trip for each account, in days. 
--Filter the results to accounts with no middle name and trips, 
--which are not cancelled (CancelDate is null).
--Order the results by Longest Trip days (descending), 
--then by Shortest Trip (ascending).
--Examples
--AccountId	FullName	LongestTrip	ShortestTrip
--40	Winna Maisey	    7	           1
--56	Tillie Windress	    7	           1
--57	Eadith Gull	        7	           1
--66	Sargent Rockhall	7	           1
--69	Jerome Flory	    7	           2

OTHER

SELECT
    a.Id AS 'AccountId'
    ,a.FirstName + ' ' + a.LastName AS 'FullName'
    ,MAX(DATEDIFF(DAY,ArrivalDate,ReturnDate)) AS LongestTrip
    ,MIN(DATEDIFF(DAY,ArrivalDate,ReturnDate)) AS ShortestTrip
FROM
    Accounts AS a JOIN AccountsTrips AS att ON a.Id = att.AccountId
    JOIN Trips AS t ON t.Id = att.TripId
WHERE
    a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY
    a.Id,a.FirstName,a.LastName
ORDER BY   
    LongestTrip DESC ,ShortestTrip

                SELECT at.AccountId,
					   CONCAT(a.FirstName, ' ', a.LastName) AS [FullName],
					   MAX(DATEDIFF(DAY, t.ArrivalDate,t.ReturnDate) AS [LongestTrip]),
					   DATEDIFF(DAY, t.ArrivalDate,t.ReturnDate) AS [ShortestTrip]
				  FROM Accounts AS a
				  JOIN AccountsTrips AS at
				    ON a.Id = at.AccountId
				  LEFT JOIN Trips AS t
				    ON t.Id = at.TripId
				 WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
		




--8. Metropolis

--Find the top 10 cities, which have the most registered accounts in them. 
--Order them by the count of accounts (descending).
--Examples
--Id	City	Country	Accounts
--76	Tyumen	RU	5
--12	Haskovo	BG	4
--33	Belfast	UK	4


SELECT TOP(10) c.Id, c.Name AS [City], c.CountryCode, COUNT(a.Id) AS [Accounts] FROM Cities AS c
JOIN Accounts AS a
ON c.Id = a.CityId
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY COUNT(a.Id) DESC


-- 9. Romantic Getaways

--Find all accounts, which have had one or more trips to a hotel in their hometown.
--Order them by the trips count (descending), then by Account ID.
--Examples
--Id	Email	             City	      Trips
--50	t_joules@mail.com	New York	   2
--19	m_stango@yahoo.com	Burgas	       1
--48	n_revitt@softuni.bg	Bradford	   1

SELECT a.Id, a.Email, c.Name , COUNT(A.Id)FROM Accounts AS a
JOIN Cities AS c
ON a.CityId = c.Id
JOIN Hotels AS h
ON h.CityId = c.Id 
JOIN AccountsTrips AS at
ON a.Id = at.AccountId
JOIN Trips AS t
ON t.Id = at.TripId
JOIN Rooms AS r
ON t.RoomId = r.Id
WHERE a.CityId = h.CityId AND a.Id = 50
GROUP BY a.Id, a.Email, c.Name
ORDER BY COUNT(A.Id) DESC,
         a.Id


		 OTHER

		 SELECT
    a.Id,a.Email,c.Name AS 'City',COUNT(a.Id) AS Trips
FROM
    Accounts AS a JOIN Cities AS c ON a.CityId = c.Id
    JOIN AccountsTrips AS att ON a.Id = att.AccountId
    JOIN Trips AS t ON t.Id = att.TripId
    JOIN Rooms AS r ON r.Id = t.RoomId
    JOIN Hotels AS h ON h.Id = r.HotelId
WHERE
    h.CityId = a.CityId
GROUP BY
    a.Id,a.Email,c.Name
ORDER BY
    Trips DESC,a.Id


 
 --a.Id, a.Email, c.Name, Count(Distinct(h.Name)) AS [Trips] 
 --a.Id, a.Email, c.Name AS [City], COUNT(h.Name) AS [Trips]

 --10. GDPR Violation

-- Retrieve the following information about each trip:
--•	Trip ID
--•	Account Full Name
--•	From – Account hometown
--•	To – Hotel city
--•	Duration – the duration between the arrival date and return date in days. If a trip is cancelled, the value is “Canceled”
--Order the results by full name, then by Trip ID.
--Examples
--Id	Full Name	               From	              To	     Duration
--273	Adah Douglass Lathaye	Stara Zagora	Cardiff	         Canceled
--491	Adah Douglass Lathaye	Stara Zagora	Houston	          4 days
--776	Adah Douglass Lathaye	Stara Zagora	Chelyabinsk	      3 days
--133	Allissa Rickey Gigg  	Austin	          Veliko Tarnovo	  6 days

SELECT t.Id, 
       RTRIM(CONCAT(a.FirstName + ' ', a.MiddleName + ' ', a.LastName + ' '))AS [FullName],
	   c.Name AS [From],
	   --(SELECT cc.Name from Cities AS cc
	   --JOIN Hotels AS hh
	   --ON cc.Id = hh.CityId
	   --WHERE hh.Name = h.Name
	   --)AS [To],
	   h.CityId AS [To],
	   CASE
	   WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
	   ELSE CONCAT(DATEDIFF(DAY,T.ArrivalDate, T.ReturnDate), ' days') 
	   END AS [Duration]
 FROM Trips AS t
JOIN AccountsTrips AS at
ON t.Id = at.TripId
JOIN Accounts AS a
ON at.AccountId = a.Id
JOIN Cities AS c
ON a.CityId = c.Id
JOIN Hotels AS h
ON c.Id = h.CityId
ORDER BY RTRIM(CONCAT(a.FirstName + ' ', a.MiddleName + ' ', a.LastName + ' ')),
         t.Id

		 OTHER

		 SELECT
    t.Id,
    a.FirstName + ISNULL (' '+ a.MiddleName+' ',' ') + a.LastName AS 'Full Name',
    c.Name AS 'From',
    cc.Name AS 'To' ,
    CASE
    WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
    ELSE CONVERT(varchar(10), DATEDIFF(DAY,ArrivalDate,ReturnDate)) + ' days'
END AS Duration
FROM
    Accounts AS a JOIN Cities AS c ON a.CityId = c.Id
    JOIN AccountsTrips AS att ON a.Id = att.AccountId
    JOIN Trips AS t ON t.Id = att.TripId
    JOIN Rooms AS r ON r.Id = t.RoomId
    JOIN Hotels AS h ON h.Id = r.HotelId
    JOIN Cities AS cc ON cc.Id = h.CityId
ORDER BY
    [Full Name],TripId

--11. Available Room 

GO

Go


CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)

RETURNS VARCHAR(MAX)
BEGIN
DECLARE @HotelBaseRate decimal(6, 2) =
										(
										SELECT BaseRate FROM Hotels
										WHERE Id = @HotelId
										)

DECLARE @RoomPrice decimal(15, 2)= (
									SELECT Price FROM Rooms
									WHERE HotelId = @HotelId
								   )

DECLARE @totalPrice DECIMAL(18,2) = (@HotelBaseRate * @RoomPrice)*@People

DECLARE @roomOcupation int = ( 
								SELECT h.Id FROM Trips AS t
								JOIN Rooms AS r
								ON T.RoomId = R.Id
								JOIN Hotels AS H
								ON H.Id = R.HotelId
								WHERE h.Id = @HotelId AND
									 @Date NOT BETWEEN t.ArrivalDate AND T.ReturnDate AND
									  t.CancelDate IS NULL AND
									  R.Beds > @People
							  )

DECLARE @ROOMID INT = (SELECT R.Id FROM Trips AS t
								JOIN Rooms AS r
								ON T.RoomId = R.Id
								JOIN Hotels AS H
								ON H.Id = R.HotelId
								WHERE h.Id = @HotelId AND
									 @Date NOT BETWEEN t.ArrivalDate AND T.ReturnDate AND
									  t.CancelDate IS NULL AND
									  R.Beds > @People
)

DECLARE @ROOMBEDS INT = (SELECT R.Beds FROM Trips AS t
								JOIN Rooms AS r
								ON T.RoomId = R.Id
								JOIN Hotels AS H
								ON H.Id = R.HotelId
								WHERE h.Id = @HotelId AND
									 @Date NOT BETWEEN t.ArrivalDate AND T.ReturnDate AND
									  t.CancelDate IS NULL AND
									  R.Beds > @People
                          )

DECLARE @ROOMTIPE nvarchar(20) = (SELECT R.Type FROM Trips AS t
								JOIN Rooms AS r
								ON T.RoomId = R.Id
								JOIN Hotels AS H
								ON H.Id = R.HotelId
								WHERE h.Id = @HotelId AND
									 @Date NOT BETWEEN t.ArrivalDate AND T.ReturnDate AND
									  t.CancelDate IS NULL AND
									  R.Beds > @People
                          )

IF(@roomOcupation IS NULL)
BEGIN
RETURN 'No rooms available'
END


RETURN (SELECT CONCAT('Room ',@ROOMID,': ',@ROOMTIPE,' (',@ROOMBEDS,' beds) - $',@totalPrice))

END

go

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)



SELECT h.Id, R.Type, R.Beds FROM Trips AS t
JOIN Rooms AS r
ON T.RoomId = R.Id
JOIN Hotels AS H
ON H.Id = R.HotelId
WHERE h.Id = 1516541 AND
     '2011-12-17' NOT BETWEEN t.ArrivalDate AND T.ReturnDate AND
	  t.CancelDate IS NULL AND
	  R.Beds >= 2 


-- 12. Switch Room
GO

CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN

END