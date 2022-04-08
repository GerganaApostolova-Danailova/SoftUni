CREATE DATABASE TableRelations

--Problem 1

CREATE TABLE Passports(
PassportID INT PRIMARY KEY IDENTITY(101,1),
PassportNumber CHAR(8) NOT NULL UNIQUE
)

ALTER TABLE Passports
ADD CONSTRAINT C_AddUnique 
UNIQUE (PassportNumber)


CREATE TABLE Persons(
PersonID INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(50) NOT NULL,
Salary DECIMAL(15,2) NOT NULL,
PassportID INT NOT NULL FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE
)

--Poblem 2

CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY IDENTITY (1,1),
[Name] NVARCHAR (50) NOT NULL,
EstablishedOn DATE NOT NULL
)

CREATE TABLE Models(
ModelID INT PRIMARY KEY IDENTITY (101,1),
[Name] NVARCHAR (50) NOT NULL,
ManufacturerID INT NOT NULL FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers([Name],EstablishedOn)
VALUES
('BMW', '03/07/1916'),
('Tesla', '01/01/2003'),
('Lada', '05/01/1966')

INSERT INTO Models([Name],ManufacturerID)
VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)

-- Problem 03. Many-To-Many Relationship 

CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY (1,1),
[Name] NVARCHAR(30) NOT NULL,
)

CREATE TABLE Exams(
ExamID INT PRIMARY KEY IDENTITY (101,1),
[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE StudentsExams(
StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
ExamID INT NOT NULL FOREIGN KEY REFERENCES Exams(ExamID),
PRIMARY KEY (StudentID,ExamID)
)

-- Problem 04. Self-Referencing 

CREATE TABLE Teachers(
TeacherID INT PRIMARY KEY IDENTITY (101,1),
[Name] NVARCHAR(100) NOT NULL,
ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers([Name],ManagerID)
VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

--Problem 5 Online Store Database

CREATE DATABASE OnlineStore

CREATE TABLE ItemTypes(
ItemTypeID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE Items(
ItemID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
ItemTypeID INT NOT NULL FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Cities(
CityID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
Birhtday DATE NOT NULL,
CityID INT NOT NULL FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
OrderID INT PRIMARY KEY IDENTITY,
CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems(
OrderID INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderID),
ItemID INT NOT NULL FOREIGN KEY REFERENCES Items(ItemID),
PRIMARY KEY (OrderID, ItemID)
)

--Problem 6. University Database

CREATE TABLE Majors (
    MajorID INT NOT NULL IDENTITY(1, 1),
    Name NVARCHAR(50) NOT NULL,

    CONSTRAINT PK_Majors PRIMARY KEY (MajorID)
)

CREATE TABLE Subjects (
    SubjectID INT NOT NULL IDENTITY(1, 1),
    SubjectName NVARCHAR(50) NOT NULL,

    CONSTRAINT PK_Subjects PRIMARY KEY (SubjectID)
)

CREATE TABLE Students (
    StudentID INT NOT NULL IDENTITY(1, 1),
    StudentNumber NVARCHAR(10) NOT NULL,
    StudentName NVARCHAR(50) NOT NULL,
    MajorID INT NOT NULL,

    CONSTRAINT PK_Students PRIMARY KEY (StudentID),
    CONSTRAINT FK_Students_Majors FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)
)

CREATE TABLE Agenda (
    StudentID INT NOT NULL,
    SubjectID INT NOT NULL,

    CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID),
    CONSTRAINT FK_Agenda_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    CONSTRAINT FK_Agenda_Subjects FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
)

CREATE TABLE Payments (
    PaymentID INT NOT NULL IDENTITY(1, 1),
    PaymentDate DATE NOT NULL,
    PaymentAmount DECIMAL(9, 2) NOT NULL,
    StudentID INT NOT NULL,

    CONSTRAINT PK_Payments PRIMARY KEY (PaymentID),
    CONSTRAINT FK_Payments_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
)

--Problem 9

SELECT MountainRange, PeakName, Elevation FROM Peaks
JOIN Mountains ON Peaks.MountainId = Mountains.Id
WHERE MountainRange = 'Rila'
Order by Elevation DESC
