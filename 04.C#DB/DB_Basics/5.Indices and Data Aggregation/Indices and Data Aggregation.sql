--Problem 1

SELECT COUNT(*) AS [Count] FROM WizzardDeposits

--Problem 2

SELECT MAX([MagicWandSize]) AS LongestMagicWand 
  FROM WizzardDeposits

--Problem 3

SELECT DepositGroup, MAX([MagicWandSize]) AS LongestMagicWand 
  FROM WizzardDeposits
GROUP BY DepositGroup

--Problem 4

SELECT TOP(2) DepositGroup
  FROM WizzardDeposits
      GROUP BY DepositGroup
      ORDER BY AVG([MagicWandSize])

--Problem 5

  SELECT DepositGroup, SUM([DepositAmount]) AS TotalSum 
    FROM WizzardDeposits
GROUP BY DepositGroup
			
--Problem 6

  SELECT DepositGroup, SUM([DepositAmount]) AS TotalSum 
    FROM WizzardDeposits
   WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--Problem 7

SELECT DepositGroup, SUM([DepositAmount]) AS TotalSum 
    FROM WizzardDeposits
   WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM([DepositAmount]) < 150000
ORDER BY TotalSum DESC

--Problem 8

SELECT DepositGroup, 
       MagicWandCreator,
       MIN([DepositCharge]) AS [MinDepositCharge]
  FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--Problem 9

SELECT AgeGroup , COUNT([FirstName]) AS [WizardCount]FROM 
     (
      SELECT 
         CASE 
           WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		   WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		   WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		   WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		   WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		   WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		   ELSE '[61+]'
          END AS [AgeGroup], *
      FROM WizzardDeposits
     ) AS [AgeQuery]
GROUP BY AgeGroup

  
--Problem 10

SELECT DISTINCT ([FirstLetter])
  FROM 
      (
       SELECT SUBSTRING(FirstName, 1,1) AS [FirstLetter] FROM WizzardDeposits
       WHERE DepositGroup = 'Troll Chest'
      ) AS [FirstLetterQuerry]
ORDER BY FirstLetter


--Problem 11

SELECT DepositGroup,
      IsDepositExpired,
       AVG(DepositInterest) AS [AverageInterest]
  FROM WizzardDeposits
  WHERE DepositStartDate > '1985-01-01'
  GROUP BY DepositGroup, IsDepositExpired
  ORDER BY DepositGroup DESC, IsDepositExpired
  
 --Problem 12
 
 SELECT SUM(Difference) AS [SumDifference]FROM
 (
 SELECT FirstName AS [Host Wizard],
        DepositAmount AS [Host Wizard Deposit],
		LEAD(FirstName) OVER(ORDER BY Id ASC) AS [Guest Wizard],
		LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Guest Wizard Deposit],
		DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Difference]
FROM WizzardDeposits
) AS [LeadQuery]
WHERE [Guest Wizard] IS NOT NULL


--Problem 13

SELECT DepartmentID, SUM(Salary) AS [TotalSalary] FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

--Problem 14

SELECT DepartmentID, MIN(Salary) AS [MinimumSalary] FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

--Problem 15

SELECT * INTO EmployeesWithHighSalaries FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithHighSalaries
WHERE ManagerID = 42

UPDATE EmployeesWithHighSalaries
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS [AverageSalary] 
FROM EmployeesWithHighSalaries
GROUP BY DepartmentID

--Problem 16

SELECT * FROM
             (
              SELECT DepartmentID, MAX(Salary) AS [MaxSalary] FROM Employees
              GROUP BY DepartmentID 
              ) AS [AllMaxSalary]
        WHERE MaxSalary NOT BETWEEN 30000 AND 70000 


--Problem 17

SELECT COUNT (*) AS [Count]
FROM Employees AS e
WHERE e.ManagerID IS NULL

--Problem 18

SELECT DISTINCT DepartmentID, ThirdHighestSalary FROM
(
SELECT DepartmentID,Salary AS [ThirdHighestSalary],
DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank] 
FROM Employees
)AS [Ranking]
WHERE Rank = 3

 --Problem 19

 SELECT TOP(10)  FirstName, 
         LastName,
		 DepartmentID 
   FROM Employees AS e
  WHERE e.Salary > (SELECT AVG(es.Salary)
                         FROM Employees es
                        WHERE e.DepartmentID = es.DepartmentID)
ORDER BY e.DepartmentID
 
 




