CREATE DATABASE Bitbucket

--1. DDL

CREATE TABLE Users
(
Id INT PRIMARY KEY IDENTITY,
Username  VARCHAR(30) NOT NULL,
[Password] VARCHAR(30) NOT NULL,
Email VARCHAR(30) NOT NULL
)

CREATE TABLE Repositories
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
CONSTRAINT PK_RepositoryContributorPK PRIMARY KEY (RepositoryId ,ContributorId)
)

CREATE TABLE Issues
(
Id INT PRIMARY KEY IDENTITY,
Title VARCHAR(255) NOT NULL,
IssueStatus VARCHAR(6) NOT NULL,
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits
(
Id INT PRIMARY KEY IDENTITY,
[Message] VARCHAR(255) NOT NULL,
IssueId INT FOREIGN KEY REFERENCES Issues(Id),
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL,
Size DECIMAL(15,2) NOT NULL,
ParentId INT FOREIGN KEY REFERENCES Files(Id),
CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)

-- Problem 02

INSERT INTO Files
VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix',	7662.92, 7, 7)

INSERT INTO Issues
VALUES
('Critical Problem with HomeController.cs file','open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs',	'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

-- 03. Update 

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--04. Delete 

DELETE FROM Issues
WHERE RepositoryId = (
                      SELECT TOP(1) Id FROM Repositories
					  WHERE Name = 'Softuni-Teamwork'
                     )

DELETE FROM Files
WHERE CommitId = (
SELECT Id FROM Commits
WHERE RepositoryId = (
                      SELECT TOP(1) Id FROM Repositories
					  WHERE Name = 'Softuni-Teamwork'
                     )
					 )

DELETE FROM Commits
WHERE RepositoryId = (
                      SELECT TOP(1) Id FROM Repositories
					  WHERE Name = 'Softuni-Teamwork'
                     )

DELETE FROM RepositoriesContributors
WHERE RepositoryId = (
                      SELECT TOP(1) Id FROM Repositories
					  WHERE Name = 'Softuni-Teamwork'
                     )

DELETE FROM Repositories
WHERE Name = 'Softuni-Teamwork'


--05. Commits 

SELECT Id, Message, RepositoryId, ContributorId FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

--06. Heavy HTML 

SELECT Id, Name, Size FROM Files
WHERE Size > 1000 AND Name LIKE '%html%'
ORDER BY Size DESC, Id, Name

--07. Issues and Users 

SELECT i.Id, CONCAT(u.Username,' : ',i.Title) AS [IssueAssignee] FROM Issues AS i
JOIN Users AS u
ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, CONCAT(u.Username,' : ',i.Title)

--08. Non-Directory Files 

SELECT f1.Id, f1.Name, CONCAT(f1.Size,'KB')AS [Size] FROM Files AS f1
LEFT JOIN Files AS f2
ON f2.ParentId = f1.Id
where f2.ParentId IS NULL
ORDER BY f1.Id, f1.Name, f1.Size DESC

--09. Most Contributed Repositories 

SELECT TOP(5) r.Id, r.Name, COUNT(c.RepositoryId) AS [Commits] FROM Repositories AS r
JOIN Commits AS c
ON r.Id = c.RepositoryId
LEFT JOIN RepositoriesContributors AS rc 
ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.Name
ORDER BY COUNT(c.Id) DESC, r.Id, r.Name

--10. User and Files 

SELECT u.Username, AVG(f.Size) AS [Size] FROM Users AS u
LEFT JOIN Commits AS c
ON U.Id = c.ContributorId
LEFT JOIN Files AS f
ON c.Id = f.CommitId
GROUP BY u.Username
ORDER BY AVG(f.Size) DESC, u.Username

--11. User Total Commits 

GO

CREATE FUNCTION udf_UserTotalCommits(@username varchar(30)) 
RETURNS INT
BEGIN
DECLARE @countOfCommits INT = 
(
SELECT COUNT(u.Id) FROM Users AS u
JOIN Commits AS c
ON u.Id = c.ContributorId
WHERE u.Username = @username
)

RETURN @countOfCommits

END

GO

SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')

GO

--12. Find by Extensions 


CREATE PROCEDURE usp_FindByExtension(@extension VARCHAR(20))
AS
BEGIN
SELECT Id, Name, CONCAT(Size,'KB')AS [Size] FROM Files
WHERE Name LIKE '%@extension'
ORDER BY Id, Name, Size DESC

END

GO

