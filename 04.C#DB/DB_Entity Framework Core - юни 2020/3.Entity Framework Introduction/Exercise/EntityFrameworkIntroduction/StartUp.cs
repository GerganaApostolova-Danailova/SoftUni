using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static object OrderBy { get; private set; }

        public static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            string result = RemoveTown(context);

            Console.WriteLine(result);
        }

        // Problem 3

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    Name = string.Join(" ", e.FirstName, e.LastName, e.MiddleName),
                    e.JobTitle,
                    e.Salary
                });

            foreach (var e in employees)
            {
                sb
                    .AppendLine($"{e.Name} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 4

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName);

            foreach (var e in employees)
            {
                sb
                    .AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }


            return sb.ToString().TrimEnd();
        }

        // Problem 5

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .ToList();


            foreach (var e in employees)
            {
                sb
                    .AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }


            return sb.ToString().TrimEnd();
        }

        //Problem 6

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses
                .Add(address);

            Employee nakov = context
                .Employees
                .First(e => e.LastName == "Nakov");

            nakov.Address = address;

            context.SaveChanges();

            var addressTexts = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new
                {
                    e.Address.AddressText
                })
                .Take(10)
                .ToList();

            foreach (var at in addressTexts)
            {
                sb.AppendLine(at.AddressText);
            }

            return sb.ToString().TrimEnd();
        }
        // Problem 7

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var targerEmployees = context.Employees
                                .Where(x => x.EmployeesProjects
                                            .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                                .Take(10)
                                .Select(x => new
                                {
                                    x.FirstName,
                                    x.LastName,
                                    ManagerFirstName = x.Manager.FirstName,
                                    ManagerLastName = x.Manager.LastName,
                                    Projects = x.EmployeesProjects
                                                        .Select(ep => new
                                                        {
                                                            ep.Project.Name,
                                                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                                            EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt"
                                                            , CultureInfo.InvariantCulture) : "not finished"
                                                        })
                                                        .ToList()
                                })
                                .ToList();

            var result = new StringBuilder();

            foreach (var employee in targerEmployees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    result.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
                }
            }
            return result.ToString().TrimEnd();
        }

        //Problem 8

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();


            var employAddress = context
                .Addresses
                .OrderByDescending(a => a.Employees.Count())
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    townName = a.Town.Name,
                    countOfEmployee = a.Employees.Count()
                })
                .ToList();



            foreach (var a in employAddress)
            {
                sb.AppendLine($"{a.AddressText}, {a.townName} - {a.countOfEmployee} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 9

        public static string GetEmployee147(SoftUniContext context)
        {

            var employee147 = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = x.EmployeesProjects.Select(p => new { p.Project.Name }).OrderBy(p => p.Name).ToList()
                })
                .First();
            var result = $"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}" + Environment.NewLine;
            foreach (var project in employee147.Projects)
            {
                result += $"{project.Name}" + Environment.NewLine;
            }

            return result.TrimEnd();
        }

        //Problem 10

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();


            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    d.Manager.FirstName,
                    employeeNameAndProdject = d.Employees
                                              .OrderBy(e => e.FirstName)
                                              .ThenBy(e => e.LastName)
                                              .Select(e => new
                                              {
                                                  e.FirstName,
                                                  e.LastName,
                                                  e.JobTitle
                                              })
                                              .ToList()

                })
                .ToList();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} – {d.FirstName}");

                foreach (var e in d.employeeNameAndProdject)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 11

        public static string GetLatestProjects(SoftUniContext context)
        {
            var lastTenProjects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .Select(x => new 
                { x.Name, 
                  x.Description, 
                  StartDate = x.StartDate.ToString("M/d/yyyy h:mm:ss tt") })
                .OrderBy(x => x.Name)
                .ToList();

            var result = new StringBuilder();

            foreach (var project in lastTenProjects)
            {
                result.AppendLine(project.Name);
                result.AppendLine(project.Description);
                result.AppendLine(project.StartDate);
            }

            return result.ToString().TrimEnd();
        }

        //Problem 12

        public static string IncreaseSalaries(SoftUniContext context)
        {
            
            var result = new StringBuilder();

            var targetEmployees = context
                .Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .ToList();



            foreach (var em in targetEmployees)
            {
                em.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employees = context.Employees.Where(x => x.Department.Name == "Engineering"
                                                        || x.Department.Name == "Tool Design"
                                                        || x.Department.Name == "Marketing"
                                                        || x.Department.Name == "Information Services")
                       .Select(x => new { x.FirstName, x.LastName, x.Salary })
                       .OrderBy(x => x.FirstName)
                       .ThenBy(x => x.LastName)
                       .ToList();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return result.ToString().TrimEnd();
        }

        //Problem 13

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeeSa = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            if (!employeeSa.Any())
            {
                return "";
            }

            foreach (var e in employeeSa)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();

        }

        //Problem 14

        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectsToDelete = context.EmployeesProjects.Where(x => x.ProjectId == 2).ToList();
            context.EmployeesProjects.RemoveRange(projectsToDelete);
            var targetProject = context.Projects.Where(x => x.ProjectId == 2).FirstOrDefault();
            context.Projects.Remove(targetProject);

            var takeProjects = context.Projects.Take(10).Select(x => new { x.Name }).ToList();
            var result = new StringBuilder();

            foreach (var proj in takeProjects)
            {
                result.AppendLine(proj.Name);
            }
            return result.ToString().TrimEnd();
        }

        //Problem 15
        public static string RemoveTown(SoftUniContext context)
        {
            var employeesInSeattle = context.Employees.Where(x => x.Address.Town.Name == "Seattle").ToList();
            foreach (var employee in employeesInSeattle)
            {
                employee.AddressId = null;
            }
            var countOfAddressesInSeattle = context.Addresses.Where(x => x.Town.Name == "Seattle").Count();
            var addressesToRemove = context.Addresses.Where(x => x.Town.Name == "Seattle").ToList();
            context.Addresses.RemoveRange(addressesToRemove);
            var targetCity = context.Towns.Where(x => x.Name == "Seattle").FirstOrDefault();
            context.Towns.Remove(targetCity);
            context.SaveChanges();
            return $"{countOfAddressesInSeattle} addresses in Seattle were deleted";
        }



    }

}

