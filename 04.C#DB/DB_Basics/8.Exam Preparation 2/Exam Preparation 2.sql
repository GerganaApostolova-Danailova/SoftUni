--1.DDL
CREATE DATABASE School

CREATE TABLE Students(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(30) NOT NULL,
Age INT CHECK(Age >=5 AND Age <= 100) NOT NULL,
[Address] NVARCHAR(50),
Phone NCHAR(10)
)

CREATE TABLE Subjects(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(20) NOT NULL,
Lessons INT CHECK(Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects(
Id INT PRIMARY KEY IDENTITY,
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
Grade DECIMAL(3,2) CHECK(Grade >=2 AND Grade <= 6) NOT NULL
)

CREATE TABLE Exams(
Id INT PRIMARY KEY IDENTITY,
[Date] DATETIME2,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
Grade DECIMAL(3,2) CHECK(Grade >=2 AND Grade <= 6) NOT NULL,
PRIMARY KEY (StudentId,ExamId)
)

CREATE TABLE Teachers(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
[Address] NVARCHAR(20)NOT NULL,
Phone CHAR(10),
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL,
PRIMARY KEY (StudentId,TeacherId)
)

--02. Insert 

INSERT INTO Teachers(FirstName, LastName, Address, Phone, SubjectId) VALUES
('Ruthanne','Bamb','84948 Mesta Junction','3105500146',6),
('Gerrard','Lowin','370 Talisman Plaza','3324874824',2),
('Merrile','Lambdin','81 Dahle Plaza','4373065154',5),
('Bert','Ivie','2 Gateway Circle','4409584510',4)



INSERT INTO Subjects(Name, Lessons)VALUES
('Geometry',12),
('Health',10),
('Drama',7),
('Sports',9)

--03. Update 

UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN (1,2) AND Grade >= 5.50


--04. Delete 

--Delete all teachers, whose phone number contains ‘72’

DELETE FROM StudentsTeachers
WHERE TeacherId IN
(
SELECT Id FROM Teachers
WHERE Phone LIKE '%72%'
)

DELETE FROM Teachers
WHERE Phone LIKE '%72%'

--05. Teen Students 

SELECT FirstName, LastName, Age FROM  Students
WHERE Age >= 12
ORDER BY FirstName, LastName

--06. Students Teachers 

SELECT s.FirstName, s.LastName, COUNT(TeacherId) AS [TeachersCount] FROM Students AS s
JOIN StudentsTeachers AS st
ON s.Id = st.StudentId
GROUP BY s.FirstName, s.LastName

--07. Students to Go 

SELECT CONCAT(s.FirstName,' ', s.LastName) AS [Full Name] 
  FROM Students AS s
       LEFT JOIN StudentsExams AS se
       ON s.Id = se.StudentId
       WHERE se.ExamId IS NULL
	   ORDER BY CONCAT(s.FirstName,' ', s.LastName)

--08. Top Students 


SELECT TOP(10) s.FirstName, s.LastName, FORMAT(ROUND(AVG(se.Grade),2),'N2') AS [Grade]
  FROM Students AS s
       LEFT JOIN StudentsExams AS se
       ON s.Id = se.StudentId
	   GROUP BY s.FirstName, s.LastName
	   ORDER BY AVG(SE.Grade) DESC, s.FirstName, s.LastName
	  

--09. Not So In The Studying 

--FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name]
--CONCAT(FirstName,' ',Isnull(MiddleName,' '),Lastname,' ')


SELECT RTRIM(
       CONCAT(s.FirstName + ' ', s.MiddleName + ' ', s.LastName + ' '))
      AS [FullName]
  FROM Students AS s
       LEFT JOIN StudentsSubjects AS ss
       ON s.Id = ss.StudentId
	   WHERE ss.SubjectId IS NULL
	   ORDER BY RTRIM(
               CONCAT(s.FirstName + ' ', s.MiddleName + ' ', s.LastName + ' '))

--10. Average Grade per Subject 

SELECT s.Name, AVG(ss.Grade) AS [AverageGrade]
  FROM StudentsSubjects AS ss
  JOIN Subjects AS s
    ON ss.SubjectId = s.Id
GROUP BY s.Name, ss.SubjectId
ORDER BY ss.SubjectId

--11. Exam Grades 

--RETURN (SELECT CONCAT('Total price ',@TotalPrice))

GO

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS VARCHAR(MAX)
BEGIN

IF (@grade > 6.00)
BEGIN
RETURN 'Grade cannot be above 6.00!'
END

DECLARE @validStudentId INT = (
                               SELECT TOP(1) Id FROM Students
                                WHERE Id = @studentId
                              )

IF(@validStudentId IS NULL)
BEGIN
RETURN 'The student with provided id does not exist in the school!'
END

DECLARE @nameOfStudent NVARCHAR(30)  = (
                                        SELECT TOP(1) FirstName FROM Students
										WHERE Id = @studentId
									   )
          

DECLARE @gradeCount INT =(
                          SELECT COUNT(se.Grade) FROM Students AS s
						  JOIN StudentsExams AS se
						  ON s.Id = se.StudentId
						  WHERE s.Id = @studentId AND se.Grade BETWEEN @grade AND (@grade + 0.50)
						 )

RETURN (SELECT CONCAT('You have to update ', @gradeCount,' grades for the student ', @nameOfStudent))

END

GO


SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

GO

--12. Exclude From School 

CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN 
 DECLARE @validId INT = (
                         SELECT TOP(1) Id FROM Students
					     WHERE Id = @StudentId
					    )
IF(@validId IS NULL)
BEGIN
RAISERROR('This school has no student with the provided id!', 16, 1)
	RETURN
END

DELETE FROM StudentsExams
WHERE StudentId = @StudentId

DELETE FROM StudentsSubjects
WHERE StudentId = @StudentId

DELETE FROM StudentsTeachers
WHERE StudentId = @StudentId

DELETE FROM Students
WHERE Id = @StudentId

END

GO

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students

EXEC usp_ExcludeFromSchool 301