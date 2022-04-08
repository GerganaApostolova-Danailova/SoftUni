namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using TeisterMask.Data.Models;
    using System.Text;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var resultBuilder = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ProjectImportDto[]), new XmlRootAttribute("Projects"));
            var reader = new StringReader(xmlString);

            var projectDtos = (ProjectImportDto[]) serializer.Deserialize(reader);

            var validProjects = new List<Project>();

            foreach (var prjDto in projectDtos)
            {
                if (!IsValid(prjDto))
                {
                    resultBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDate;

                var openDateIsParsed = DateTime.TryParseExact(prjDto.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out openDate);

                if (!openDateIsParsed)
                {
                    resultBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                var project = new Project
                {
                    Name = prjDto.Name,
                    OpenDate = openDate,
                    DueDate = null
                };

                DateTime dueDate;

                var dueDateIsParsed = DateTime.TryParseExact(prjDto.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDate);

                if (dueDateIsParsed)
                {
                    project.DueDate = dueDate;
                }

                foreach (var taskDto in prjDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        resultBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;

                    var taskOpenDateIsParsed = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);
                                                                  //31/01/2018   //19/08/2018
                    if (!taskOpenDateIsParsed || DateTime.Compare(taskOpenDate,project.OpenDate) < 0)
                    {
                        resultBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate;

                    var taskDueDateIsParsed = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!taskDueDateIsParsed || (project.DueDate.HasValue && DateTime.Compare(dueDate, taskDueDate) < 0))
                    {
                        resultBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validTask = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    };

                    project.Tasks.Add(validTask);                  
                }

                validProjects.Add(project);
                resultBuilder.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(validProjects);
            context.SaveChanges();

            return resultBuilder.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var resultBuilder = new StringBuilder();

            var employeeDtos = JsonConvert.DeserializeObject<EmployeeImportDto[]>(jsonString);

            var validEmployees = new List<Employee>();
            var validEmployeeTasks = new List<EmployeeTask>();

            foreach (var empDto in employeeDtos)
            {
                if (!IsValid(empDto))
                {
                    resultBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = empDto.Username,
                    Email = empDto.Email,
                    Phone = empDto.Phone
                };

                var taskIds = empDto
                    .Tasks
                    .Distinct()
                    .ToArray();

                var existingTasks = context.Tasks
                    .Select(t => t.Id)
                    .ToArray();

                foreach (var taskId in taskIds)
                {
                    if (!existingTasks.Contains(taskId))
                    {
                        resultBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    var employeeTask = new EmployeeTask
                    {
                        TaskId = taskId,
                        Employee = employee
                    };

                    context.EmployeesTasks.Add(employeeTask);
                }

                validEmployees.Add(employee);
                resultBuilder.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(validEmployees);
            context.EmployeesTasks.AddRange(validEmployeeTasks);
            context.SaveChanges();


            return resultBuilder.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}