--Problem 1
CREATE DATABASE Minions

--Problem 2
CREATE TABLE Minions(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(20) NOT NULL,
Age INT
)

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(20) NOT NULL,
)

--Problem 3

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

--Problem 4

 SET IDENTITY_INSERT Towns ON
 -- ТОВА Е ЗАЩОТО ПО-ГОРЕ СМЕ 
 --ДАЛИ identity, А ДОЛУ СИ ГИ ПОПЪЛВАМЕ РЪЧНО

INSERT INTO Towns(Id, Name)VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions (Id,Name,Age,TownId)
VALUES 
(1,'Kevin', 22, 1),
(2,'Bob', 15, 3),
(3,'Steward', NULL, 2)

SET IDENTITY_INSERT Minions OFF
SET IDENTITY_INSERT Minions ON

--Problem 5
TRUNCATE TABLE Minions

--Problem 6
DROP TABLE Minions
DROP TABLE Towns

--Prolem 7

CREATE TABLE People (
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX),
Height DECIMAL(5,2),
Weight DECIMAL(5,2),
Gender char(1) NOT NULL CHECK(Gender='m' OR Gender='f'),
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People (Name, Picture,Height, Weight, Gender, Birthdate,Biography)
VALUES
('Pesho', NULL, 1.70, 73.5, 'm', '2001-09-22', NULL),
('Gosho', NULL, 1.70, 73.5, 'm', '1987-09-22', NULL),
('Mimi', NULL, 1.50, 53.5, 'f', '1984-09-22', NULL),
('Geri', NULL, 1.70, 73.5, 'f','2000-09-22', NULL),
('Stamen', NULL, 1.70, 73.5, 'm','2001-09-22', NULL)

--Problem 8

CREATE TABLE Users (
Id INT PRIMARY KEY IDENTITY,
Username  VARCHAR(30) NOT NULL ,
Password  VARCHAR(26) NOT NULL,
ProfilePicture  VARBINARY(MAX),
LastLoginTime DATE,
IsDeleted NVARCHAR(5) NOT NULL CHECK(IsDeleted='true' OR IsDeleted='false')
)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Pesho', 'jhcwsh', NULL, '2001-09-22','true'),
('Gosho', 'gweggr', NULL, '2001-09-22','false'),
('Gencho', 'jhcgrgwsh', NULL, '2001-09-22','true'),
('Marusia', 'grgwgrw', NULL, '2001-09-22','false'),
('Mimi', 'jggwgrhcwsh', NULL, '2001-09-22','true')

--Moe si
TRUNCATE TABLE Users

--Problem 9

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07901F6F5E
ALTER TABLE Users
ADD CONSTRAINT PK_CUSTID 
PRIMARY KEY (Id, Username)

--Problem 10 

ALTER TABLE Users
ADD CONSTRAINT CK_Users_LenghtOfPassword
CHECK(LEN (Password) >= 5)

--Problem 11

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime 
DEFAULT GETDATE()
FOR LastLoginTime

-- Problem 12

ALTER TABLE Users
DROP CONSTRAINT PK_CUSTID

ALTER TABLE Users
ADD CONSTRAINT PK_Users
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CK_LenghtOfUsername
CHECK(LEN (Username) >= 3)

-- Problem 13

CREATE DATABASE Movies

CREATE TABLE Directors( 
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Genres ( 
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Categories  ( 
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Movies( 
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
CopyrightYear INT NOT NULL,
Length INT NOT NULL,
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating DECIMAL (3,1) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Directors (DirectorName, Notes) 
     VALUES ('Francis Ford Coppola', 'He was born in 1939 in Detroit.'),
            ('Christopher Nolan', 'He was born on July 30, 1970 in London, England.'),
            ('Tony Kaye', 'Tony Kaye was born in London, United Kingdom.'),
            ('Ridley Scott', 'He was born on November 30, 1937 in South Shields.'),
            ('Brian De Palma', 'He was born in 1940.')

INSERT INTO Genres (GenreName, Notes) 
     VALUES ('Action', 'Cool genre.'),
            ('Comedy', 'Very funny'),
            ('Historical', 'A story for real person or event.'),
            ('Science fiction', 'Cool genre.'),
            ('Fantasy', NULL)

INSERT INTO Categories (CategoryName, Notes) 
     VALUES ('Great', 'The greatest'),
            ('Very good', 'very good film'),
            ('Good', 'Good film'),
            ('Poor', 'Very poor film'),
            ('Awful', 'Just AWFUL')

INSERT INTO Movies (Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes) 
     VALUES ('The Godfather', 1, 1972, 175, 1, 1, 9.2, 'The best film ever.'),
            ('The Dark Knight', 2, 2008, 152, 4, 1, 9, 'Other the best film ever.'),
            ('American History X', 3, 1998, 119, 3, 2, 8.5, 'Very very good film'),
            ('Gladiator', 4, 2000, 155, 3, 2, 8.5, 'Very very good film'),
            ('Scarface', 5, 1983, 170, 1, 1, 8.3, 'Very very good film')
--mOE SI


DROP TABLE Movies
DROP TABLE Categories

-- Problem 14

CREATE DATABASE CarRental 

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(50) NOT NULL,
DailyRate DECIMAL (9,2),
WeeklyRate DECIMAL (9,2),
MonthlyRate DECIMAL (9,2),
WeekendRate DECIMAL (9,2)
)

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY,
PlateNumber NVARCHAR(15) NOT NULL,
Manufacturer NVARCHAR(25) NOT NULL,
Model NVARCHAR(25) NOT NULL,
CarYear INT NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Doors INT NOT NULL,
Picture VARBINARY(MAX),
Condition NVARCHAR(MAX) NOT NULL,
Available INT
)

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Title NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX) NOT NULL
)

CREATE TABLE Customers  (
Id INT PRIMARY KEY IDENTITY,
DriverLicenceNumber INT NOT NULL,
FullName NVARCHAR(50) NOT NULL,
Address NVARCHAR(50) NOT NULL,
City NVARCHAR(20) NOT NULL,
ZIPCode INT NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders (
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees (Id),
CustomerId INT FOREIGN KEY REFERENCES Customers (Id),
CarId INT FOREIGN KEY REFERENCES Cars (Id),
TankLevel INT NOT NULL,
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage AS KilometrageEnd - KilometrageStart,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
RateApplied DECIMAL(9, 2),
TaxRate DECIMAL(9, 2),
OrderStatus NVARCHAR(50),
Notes NVARCHAR(MAX)
)

INSERT INTO Categories (CategoryName, DailyRate, WeekLyRate, MonthlyRate, WeekendRate) 
     VALUES ('Car', 20, 120, 500, 42.50),
            ('Bus', 250, 1600, 6000, 489.99),
            ('Truck', 500, 3000, 11900, 949.90)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) 
     VALUES ('123456ABCD', 'Mazda', 'CX-5', 2016, 1, 5, null, 'Perfect', 1),
            ('asdafof145', 'Mercedes', 'Tourismo', 2017, 2, 3,null, 'Perfect', 1),
            ('asdp230456', 'MAN', 'TGX', 2016, 3, 2, null, 'Perfect', 1)

INSERT INTO Employees (FirstName, LastName, Title, Notes) 
     VALUES ('Ivan', 'Ivanov', 'Seller', 'I am Ivan'),
            ('Georgi', 'Georgiev', 'Seller', 'I am Gosho'),
            ('Mitko', 'Mitkov', 'Manager', 'I am Mitko')

INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
     VALUES (123456789, 'Gogo Gogov', 'óë. Ïèðîòñêà 5', 'Ñîôèÿ', 1233, 'Good driver'),
            (347645231, 'Mara Mareva', 'óë. Èâàí Äðàñîâ 14', 'Âàðíà', 5678, 'Bad driver'),
            (123574322, 'Strahil Strahilov', 'óë. Êåñòåí 4', 'Äóïíèöà', 5689, 'Good driver')

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate) 
     VALUES (1, 1, 1, 54, 2189, 2456, '2017-11-05', '2017-11-08'),
            (2, 2, 2, 22, 13565, 14258, '2017-11-06', '2017-11-11'),
            (3, 3, 3, 180, 1202, 1964, '2017-11-09', '2017-11-12')

--Problem 15

CREATE DATABASE Hotel

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY (1,1),
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Title NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX) NOT NULL
)

CREATE TABLE Customers (
AccountNumber INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
PhoneNumber NVARCHAR(50) NOT NULL,
EmergencyName NVARCHAR(50) ,
EmergencyNumber NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus(
RoomStatus NVARCHAR(50) PRIMARY KEY,
Notes NVARCHAR(MAX)
) 

CREATE TABLE RoomTypes(
RoomType NVARCHAR(50) PRIMARY KEY,
Notes NVARCHAR(MAX)
) 

CREATE TABLE BedTypes(
BedType NVARCHAR(50) PRIMARY KEY,
Notes NVARCHAR(MAX)
) 

CREATE TABLE Rooms(
RoomNumber INT PRIMARY KEY IDENTITY(1,1),
RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType),
Rate DECIMAL(9,2),
RoomStatus NVARCHAR(50) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
Notes NVARCHAR(MAX)
)



CREATE TABLE Payments (
Id INT PRIMARY KEY IDENTITY (1,1),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATE NOT NULL,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
FirstDateOccupied DATE NOT NULL,
LastDateOccupied DATE NOT NULL,
TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
AmountCharged DECIMAL(9, 2) NOT NULL,
TaxRate DECIMAL(9, 2),
TaxAmount DECIMAL(9, 2),
PaymentTotal DECIMAL(9, 2),
Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies(
Id INT PRIMARY KEY IDENTITY (1,1),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATE,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied DECIMAL (9,2),
PhoneCharge DECIMAL(9, 2),
Notes NVARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title, Notes) 
     VALUES ('Ivan', 'Ivanov', 'Receptionist', 'I am Ivan'),
            ('Martin', 'Martinov', 'Technical support', 'I am Martin'),
            ('Mara', 'Mareva', 'Cleaner', 'I am Marcheto')

INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyNumber)
     VALUES ('Pesho', 'Peshov', '+395883333333', '123'),
            ('Gosho', 'Goshov', '+395882222222', '123'),
            ('Kosio', 'Kosiov', '+395888888888', '123')

INSERT INTO RoomStatus (RoomStatus, Notes) 
     VALUES ('Clean', 'The room is clean.'),
            ('Dirty', 'The room is dirty.'),
            ('Repair', 'The room is for repair.')

INSERT INTO RoomTypes (RoomType, Notes)
     VALUES ('Small', 'Room with one bed'),
            ('Medium', 'Room with two beds'),
            ('Large', 'Room with three beds')

INSERT INTO BedTypes (BedType)
     VALUES ('Normal'),
            ('Comfort'),
            ('VIP')

INSERT INTO Rooms (RoomType, BedType, Rate, RoomStatus)
     VALUES ('Small', 'Normal', 50, 'Dirty'),
            ('Medium', 'Comfort', 70, 'Clean'),
            ('Large', 'VIP', 100, 'Repair')

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate)
     VALUES (1, '2015-05-06', 1, '2015-06-18', '2015-07-03', 1256.33, 166.23),
            (2, '2017-10-11', 2, '2017-10-12', '2017-10-22', 556, 125.95),
            (3, '2017-10-26', 3, '2017-11-09', '2017-11-11', 146.74, 100)

INSERT INTO Occupancies (EmployeeId, AccountNumber, RoomNumber, RateApplied)
     VALUES (1, 1, 1, 55.55),
            (2, 2, 2, 44.44),
            (3, 3, 3, 33.33)
--Problem 16

CREATE DATABASE SoftUni;

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(20)
)

CREATE TABLE Addresses (
Id INT PRIMARY KEY IDENTITY,
AddressText NVARCHAR(30),
TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments (
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(30)
)

CREATE TABLE Employees  (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30),
MiddleName NVARCHAR(30),
LastName NVARCHAR(30),
JobTitle NVARCHAR(30),
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
HireDate DATETIME NOT NULL,
Salary DECIMAL (15,2) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)	

-- Problem 17
--Back Up
-- Десен бутон SoftUni -> Tasks -> Back Up Database -> Ok
-- За да ресторнеш -> Десен бутон SoftUni -> Tasks -> Restore -> Database
-- Device -> избираш му пътя, слагаш отметка и Ок

-- Problem 18

INSERT INTO Towns (Name)
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments (Name)
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')


INSERT INTO Employees (FirstName, JobTitle,DepartmentId,HireDate, Salary)
VALUES
('Ivan Ivanov Ivanov','.NET Developer',4,01/02/2013, 3500.00),
('Petar Ivanov Ivanov','Senior Engineer',1,02/03/2004, 4000.00),
('Maria Ivanov Ivanov','Intern',5,28/08/2016, 525.25),
('Georgi Ivanov Ivanov','CEO',2,09/12/2007, 3000.00),
('Peter Pan Pan','Intern',3,28/08/2016, 599.88)

-- Problem 19

SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--Problem 20

SELECT * FROM Towns
ORDER BY Name

SELECT * FROM Departments
ORDER BY Name

SELECT * FROM Employees
ORDER BY Salary DESC

--Problem 21

SELECT Name FROM Towns
ORDER BY Name

SELECT Name FROM Departments
ORDER BY Name

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--Problem 22

UPDATE Employees
SET Salary = Salary *1.1
SELECT Salary FROM Employees

--Problem 23

UPDATE Payments
SET TaxRate -= TaxRate * 0.03 
SELECT TaxRate FROM Payments

--Problem 24

TRUNCATE TABLE Occupancies 


