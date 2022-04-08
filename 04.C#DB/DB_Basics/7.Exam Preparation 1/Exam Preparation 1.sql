--1. Section 1

CREATE DATABASE Airport

CREATE TABLE Planes(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
Seats INT NOT NULL,
[Range] INT NOT NULL
)


CREATE TABLE Flights(
Id INT PRIMARY KEY IDENTITY,
DepartureTime DATETIME2,
ArrivalTime DATETIME2,
Origin VARCHAR(50) NOT NULL,
Destination VARCHAR(50) NOT NULL,
PlaneId INT NOT NULL FOREIGN KEY REFERENCES Planes(Id)
)

CREATE TABLE Passengers(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
Age INT NOT NULL,
[Address] VARCHAR(30) NOT NULL,
PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes(
Id INT PRIMARY KEY IDENTITY,
[Type] VARCHAR(30) NOT NULL,
)

CREATE TABLE Luggages(
Id INT PRIMARY KEY IDENTITY,
LuggageTypeId INT NOT NULL FOREIGN KEY REFERENCES LuggageTypes(Id),
PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
)

CREATE TABLE Tickets(
Id INT PRIMARY KEY IDENTITY,
PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
FlightId INT NOT NULL FOREIGN KEY REFERENCES Flights(Id),
LuggageId INT NOT NULL FOREIGN KEY REFERENCES Luggages(Id),
Price DECIMAL(15,2) NOT NULL
)

--2. Insert

INSERT INTO Planes([Name], Seats, [Range])
VALUES
('Airbus 336',112,5132),
('Airbus 330',432,5325),
('Boeing 369',231,2355),
('Stelt 297',254,2143),
('Boeing 338',165,5111),
('Airbus 558',387,1342),
('Boeing 128',345,5541)


INSERT INTO LuggageTypes ([Type])
VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--3.UPDATE

UPDATE Tickets
SET Price*= 1.13
WHERE FlightId IN (
                   SELECT Id 
                   FROM Flights
                   WHERE Destination = 'Carlsbad'
                   )
--4. Delite

DELETE FROM Tickets
WHERE FlightId IN (
                  SELECT Id FROM Flights
                  WHERE Destination = 'Ayn Halagim'
			      )

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

--05. The "Tr" Planes 

SELECT * FROM Planes
WHERE Name LIKE '%tr%'
ORDER BY Id, [Name], Seats,[Range]


-- 06. Flight Profits 

SELECT t.FlightId, SUM(Price) AS [Price] FROM Tickets AS t
GROUP BY FlightId
ORDER BY SUM(Price) DESC, t.FlightId

--07. Passenger Trips 

SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name],
       f.Origin,
	   f.Destination
  FROM Passengers AS p
JOIN Tickets AS t
ON p.Id = t.PassengerId
JOIN Flights AS f
ON f.Id = t.FlightId
ORDER BY CONCAT(FirstName, ' ', LastName),
         f.Origin,
		 f.Destination

--08. Non Adventures People 

SELECT p.FirstName, p.LastName, p.Age FROM Passengers AS p
LEFT JOIN Tickets AS t
ON p.Id = t.PassengerId
WHERE t.Id IS NULL
ORDER BY Age DESC,
         P.FirstName,
		 P.LastName

-- 09. Full Info 

SELECT * FROM
(
SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
       pl.Name AS [Plane Name],
	   CONCAT(f.Origin,' - ', f.Destination) AS [Trip],
	   lt.[Type] AS [Luggage Type]
  FROM Passengers AS p
JOIN Tickets AS t
ON p.Id = t.PassengerId
JOIN Flights AS f
ON f.Id = t.FlightId
JOIN Planes AS pl
ON f.PlaneId = pl.Id
JOIN Luggages AS l
ON t.LuggageId = l.Id
JOIN LuggageTypes AS lt
ON l.LuggageTypeId = lt.Id
) AS [InfoQuery]
ORDER BY [Full Name], [Plane Name], Trip, [Luggage Type]

--10. PSP 

SELECT pl.Name, 
       pl.Seats,
	   COUNT(t.PassengerId)
  FROM Planes AS pl
LEFT JOIN Flights AS f
ON pl.Id = f.PlaneId
LEFT JOIN Tickets AS t
ON t.FlightId = f.Id
GROUP BY pl.Name, pl.Seats
ORDER BY COUNT(t.PassengerId) DESC, pl.Name, pl.Seats

--11. Vacation


GO

 CREATE FUNCTION 
 udf_CalculateTickets(
                      @origin varchar(50) , 
                      @destination varchar(50), 
					  @peopleCount INT
					  )
RETURNS VARCHAR(50)
BEGIN
IF @peopleCount <= 0
BEGIN
RETURN 'Invalid people count!'
END

DECLARE @InvalidId INT = (
                          SELECT TOP(1) Id FROM Flights
                           WHERE Origin = @origin AND 
						         Destination = @destination
						  )  

IF (@InvalidId IS NULL)
BEGIN
RETURN 'Invalid flight!'
END

DECLARE @PricePerPlane DECIMAL(18,2) = (
                                        SELECT TOP(1) Price 
                                          FROM Tickets 
                                         WHERE FlightId = @InvalidId
                                        )

DECLARE @TotalPrice DECIMAL(24,2) =  @PricePerPlane * @peopleCount
    
RETURN (SELECT CONCAT('Total price ',@TotalPrice))

END

GO

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)	
		
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)

SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

--12. Wrong Data 

GO

CREATE PROC usp_CancelFlights
AS
UPDATE Flights
SET DepartureTime = NULL, ArrivalTime = NULL
WHERE ArrivalTime > DepartureTime
 
 EXEC dbo.usp_CancelFlights