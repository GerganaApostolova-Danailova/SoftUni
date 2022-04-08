--Problem 1

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
SELECT FirstName, 
       LastName 
  FROM Employees
 WHERE Salary > 35000
END
 GO

EXEC dbo.usp_GetEmployeesSalaryAbove35000

GO

--Problem 2

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@NumSalary DECIMAL(18,4))
AS
BEGIN
SELECT FirstName, 
       LastName 
  FROM Employees
 WHERE Salary >= @NumSalary
END

GO 

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100

GO

--Problem 3

CREATE PROCEDURE usp_GetTownsStartingWith(@StrParameter NVARCHAR(50))
AS
BEGIN
SELECT Name AS [Town] 
  FROM Towns
WHERE SUBSTRING(Name,1,LEN(@StrParameter)) = @StrParameter
END

GO

EXEC DBO.usp_GetTownsStartingWith b

GO

--Problem 4

CREATE PROCEDURE usp_GetEmployeesFromTown(@TownName NVARCHAR(50))
AS
BEGIN
SELECT e.FirstName, e.LastName 
  FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
WHERE t.Name = @TownName
END

GO

EXEC DBO.usp_GetEmployeesFromTown 'Sofia'

GO

--Problem 5

GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(7)
AS
BEGIN
DECLARE @SalaryLevel NVARCHAR(7)

IF (@salary < 30000)
 SET @SalaryLevel = 'Low'

ELSE IF (@salary >= 30000 AND @salary <= 50000)
 SET @SalaryLevel = 'Average'

 ELSE 
 SET @SalaryLevel = 'High'

 RETURN @SalaryLevel
END

GO

SELECT Salary,
       dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
  FROM Employees

--Problem 6

GO

CREATE PROCEDURE usp_EmployeesBySalaryLevel(@parameterLevel VARCHAR(7))
AS
BEGIN
SELECT FirstName, 
       LastName
  FROM Employees
  WHERE dbo.ufn_GetSalaryLevel(Salary) = @parameterLevel
END

GO

EXEC dbo.usp_EmployeesBySalaryLevel'High'

--Problem 7

GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX)) 
RETURNS BIT
AS
BEGIN
DECLARE @Index INT = 1
    WHILE (@Index <= LEN(@Word))
    BEGIN
        DECLARE @Symbol NVARCHAR(1) = SUBSTRING(@Word, @Index, 1)
        IF (CHARINDEX(@Symbol, @SetOfLetters, 1) = 0)
        BEGIN
            RETURN 0
        END
        SET @Index += 1
    END
    RETURN 1
END

--Problem 8

GO

CREATE PROC usp_DeleteEmployeesFromDepartment (@DepartmentId INT)
AS
BEGIN
    DECLARE @EmployeesIdToDelete TABLE (Id INT)

    INSERT INTO @EmployeesIdToDelete
         SELECT e.EmployeeID
           FROM Employees e
          WHERE e.DepartmentID = @DepartmentId

     ALTER TABLE Departments
    ALTER COLUMN ManagerID INT NULL
    
    DELETE FROM EmployeesProjects
          WHERE EmployeeID IN (SELECT Id FROM @EmployeesIdToDelete)

    UPDATE Employees
       SET ManagerID = NULL
     WHERE ManagerID IN (SELECT Id FROM @EmployeesIdToDelete)

    UPDATE Departments
       SET ManagerId = NULL
     WHERE ManagerID IN (SELECT Id FROM @EmployeesIdToDelete)

    DELETE FROM Employees
          WHERE EmployeeID IN (SELECT Id FROM @EmployeesIdToDelete)

    DELETE FROM Departments
          WHERE DepartmentID = @DepartmentId

        SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
    INNER JOIN Departments AS d
            ON d.DepartmentID = e.DepartmentID
         WHERE e.DepartmentID = @DepartmentId
END

--Problem 9

GO

CREATE PROC usp_GetHoldersFullName
AS
BEGIN
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] 
  FROM AccountHolders
END

EXEC dbo.usp_GetHoldersFullName

--Problem 10

GO

CREATE PROC usp_GetHoldersWithBalanceHigherThan(@balance DECIMAL(18,4))
AS
BEGIN
SELECT ah.FirstName, ah.LastName  FROM Accounts AS a 
JOIN AccountHolders AS ah
ON a.AccountHolderId = ah.Id
GROUP BY ah.FirstName, ah.LastName 
HAVING SUM(Balance) > @balance
ORDER BY FirstName, LastName
END

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 20000.00

--Problem 11

GO

CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(15,2),@yearlyInterest FLOAT, @numYears INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
DECLARE @result DECIMAL(18,4)

SET @result = @sum * POWER((1+ @yearlyInterest), @numYears)

RETURN @result 

END

--Problem 12

GO

CREATE PROCEDURE usp_CalculateFutureValueForAccount(@Id INT, @yearlyInterest FLOAT)
AS
BEGIN
SELECT a.Id,  
       ah.FirstName,  
	   ah.LastName , 
	   a.Balance AS [Current Balance],
	   dbo.ufn_CalculateFutureValue(Balance, 0.1, 5) AS [Balance in 5 years]
   FROM Accounts AS a 
JOIN AccountHolders AS ah
ON a.AccountHolderId = ah.Id
WHERE a.Id = @Id
END

EXEC dbo.usp_CalculateFutureValueForAccount 1 , 0.1

--Problem 13

GO

CREATE FUNCTION ufn_CashInUsersGames (@GameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN (
    WITH CTE_CashInRows (Cash, RowNumber)
    AS
    (
         SELECT ug.Cash,
                ROW_NUMBER() OVER (ORDER BY ug.Cash DESC)
           FROM UsersGames ug
     INNER JOIN Games g
             ON g.Id = ug.GameId
          WHERE g.Name = @GameName
    )

    SELECT SUM(Cash) AS [SumCash]
      FROM CTE_CashInRows
     WHERE RowNumber % 2 = 1
)

