
--Problem 1

SELECT TOP (5) e.EmployeeID, 
       e.JobTitle, 
	   e.AddressID, 
	   a.AddressText 
  FROM Employees AS e
INNER JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY E.AddressID


--Problem 2

SELECT TOP(50) e.FirstName, e.LastName,t.Name AS [Town], a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON  a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

--Problem 3

SELECT e.EmployeeID, 
       e.FirstName,
	   e.LastName, 
	   d.Name AS [DepartmentName] 
  FROM Employees AS e
       JOIN Departments AS d
       ON e.DepartmentID = d.DepartmentId
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

--Problem 4

SELECT TOP(5) 
       e.EmployeeID, 
       e.FirstName,
	   e.Salary,
	   d.Name AS [DepartmentName] 
  FROM Employees AS e
       JOIN Departments AS d
       ON e.DepartmentID = d.DepartmentId
WHERE Salary > 15000
ORDER BY d.DepartmentID

--Problem 5

SELECT TOP(3) e.EmployeeID, e.FirstName FROM Employees AS e
LEFT  JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p
ON p.ProjectID = ep.ProjectID
WHERE p.ProjectID IS NULL
ORDER BY e.EmployeeID

--Problem 6

SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS [DeptName] FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01'AND d.Name IN ('Sales', 'Finance')
ORDER BY d.Name

--Problem 7

SELECT  TOP(5) e.EmployeeID, e.FirstName , p.Name AS [ProdectName] FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--Problem 8

SELECT 
      ep.EmployeeID, 
	  e.FirstName ,
	  CASE
	        WHEN DATEPART(YEAR, p.StartDate) >= '2005' THEN NULL
	        ELSE p.Name
	   END AS [ProdectName] 
  FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
ON p.ProjectID = ep.ProjectID
WHERE ep.EmployeeID = 24 

--Problem 9

SELECT e1.EmployeeID, 
       e1.FirstName ,   
	   e1.ManagerID,  
	   e2.FirstName AS [ManagerName] 
  FROM Employees AS e1
  JOIN Employees AS e2
    ON e2.EmployeeID = e1.ManagerID
 WHERE e1.ManagerID IN (3,7)
ORDER BY e1.EmployeeID

--Problem 10

SELECT TOP(50) e1.EmployeeID, 
       CONCAT(e1.FirstName, ' ', e1.LastName) AS [EmployeeName],   
	   CONCAT(e2.FirstName, ' ', e2.LastName) AS [ManagerName],
	   d.Name AS [DepartmentName]
  FROM Employees AS e1
  LEFT JOIN Employees AS e2
    ON e2.EmployeeID = e1.ManagerID
  JOIN Departments AS d
	ON e1.DepartmentID = d.DepartmentID
ORDER BY e1.EmployeeID


--Problem 11

SELECT MIN([AverageSalary])AS [MinAverageSalary] 
FROM
     ( 
	   SELECT DepartmentID, AVG(Salary) as [AverageSalary] 
	   FROM Employees
       GROUP BY DepartmentID
	  ) AS [GroypBySalary]


--Problem 12

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation FROM MountainsCountries AS mc
JOIN Countries AS c
ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m
ON mc.MountainId = m.Id
JOIN Peaks AS p
ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND P.Elevation > 2835
ORDER BY Elevation DESC

--Problem 13

SELECT CountryCode, [MountineCount] AS [MountainRanges] FROM
      (
       SELECT mc.CountryCode, COUNT(m.MountainRange) AS [MountineCount] FROM MountainsCountries AS mc
       JOIN Mountains AS m
       ON mc.MountainId = m.Id
       GROUP BY mc.CountryCode
	  ) AS [MountainRange]
WHERE CountryCode IN ('BG', 'RU', 'US')
ORDER BY MountineCount DESC

--Problem 14

SELECT TOP(5) c.CountryName, r.RiverName FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

--Problem 15

WITH CTE_Count (ContinentCode, CurrancyCode, CurrancyUsage)
AS
( 
  SELECT c.ContinentCode,
         c.CurrencyCode,
         COUNT(c.CurrencyCode) AS [CurrancyUsage]
    FROM Countries c
GROUP BY c.ContinentCode, 
         c.CurrencyCode
  HAVING COUNT(c.CountryCode) > 1
)

    SELECT cmax.ContinentCode,
           cte.CurrancyCode,
           cmax.CurrancyUsage
      FROM (  SELECT ContinentCode,
                       MAX(CurrancyUsage) AS [CurrancyUsage]
                  FROM CTE_Count
              GROUP BY ContinentCode) AS cmax
INNER JOIN CTE_Count cte
        ON (cmax.ContinentCode = cte.ContinentCode AND cmax.CurrancyUsage = cte.CurrancyUsage)
  ORDER BY cmax.ContinentCode


-- Problem 16

SELECT COUNT(*) AS [Count]
 FROM
        (
         SELECT c.CountryCode, COUNT(m.MountainRange) AS [MountineCount] FROM Countries AS c
         LEFT JOIN MountainsCountries AS mc
         ON c.CountryCode = mc.CountryCode
         LEFT JOIN Mountains AS m
         ON mc.MountainId = m.Id
         GROUP BY c.CountryCode
         ) AS [CountriesWithOrWithoutMount]
WHERE MountineCount = 0

--Problem 17

SELECT TOP(5) c.CountryName, 
       MAX(p.Elevation) AS [HighestPeakElevation], 
	   MAX(r.Length) AS [LongestRiverLength] 
  FROM Countries AS c
       LEFT JOIN CountriesRivers AS cr
       ON c.CountryCode = cr.CountryCode
       LEFT JOIN Rivers AS r
       ON cr.RiverId = r.Id
       LEFT JOIN MountainsCountries AS mc
       ON  c.CountryCode = mc.CountryCode
       LEFT JOIN Mountains AS m
       ON mc.MountainId = m.Id
       LEFT JOIN Peaks AS p
       ON p.MountainId = m.Id
       GROUP BY c.CountryName
       ORDER BY [HighestPeakElevation] DESC, 
	            [LongestRiverLength] DESC, 
	            c.CountryName 


--Problem 18

SELECT TOP 5
           c.CountryName,
           ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name],
           ISNULL(P.Elevation, 0) AS [Highest Peak Elevation],
           ISNULL(m.MountainRange, '(no mountain)') AS [Mountain]
      FROM Countries c
 LEFT JOIN MountainsCountries mc
        ON mc.CountryCode = c.CountryCode
 LEFT JOIN Mountains m
        ON m.Id = mc.MountainId
 LEFT JOIN Peaks p
        ON p.MountainId = mc.MountainId
  ORDER BY c.CountryName,
           P.PeakName


