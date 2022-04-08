namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Runtime.InteropServices;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.XMLHelper;
    using TeisterMask.Data.Models;
    using System.Text;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Linq;
    using Castle.Core.Internal;
    using System.Xml.Serialization;
    using System.IO;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(List<ImportProjectsDto>), new XmlRootAttribute("Projects"));

            var projectDtos = (List<ImportProjectsDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Project> projects = new List<Project>();

            List<Task> tasks = new List<Task>();

            foreach (var projectDto in projectDtos)
            {
                if (!IsValid(projectDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime projectOpenDate;
                bool isProjectOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);

                DateTime? projectDueDate;

                if (!string.IsNullOrEmpty(projectDto.DueDate) && !string.IsNullOrWhiteSpace(projectDto.DueDate))
                {
                    projectDueDate = DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    projectDueDate = null;
                }

                if (!isProjectOpenDateValid)
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                Project validProject = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate
                };

                int taskCount = 0;

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    bool isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                    DateTime taskDueDate;
                    bool isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!isTaskOpenDateValid || !isTaskDueDateValid)
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < projectOpenDate)
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskDueDate > projectDueDate)
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task validTask = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType,
                        Project = validProject
                    };

                    tasks.Add(validTask);
                    taskCount++;
                }

                projects.Add(validProject);
                stringBuilder.AppendLine(string.Format(SuccessfullyImportedProject, validProject.Name, taskCount));
            }

            context.Projects.AddRange(projects);
            context.Tasks.AddRange(tasks);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();

            //var xmlResult = XmlConverter.Deserializer<ImportProjectsDto>(xmlString, "Projects");

            //var projects = new List<Project>();

            //StringBuilder sb = new StringBuilder();

            //foreach (ImportProjectsDto projectsDto in xmlResult)
            //{
            //    if (!IsValid(projectsDto))
            //    {
            //        sb
            //           .AppendLine(ErrorMessage);
            //        continue;
            //    }

            //    DateTime projectOpenDate;
            //    bool isValidProjectoOpenDate = DateTime.TryParseExact(projectsDto.OpenDate, "MM/dd/yyyy",
            //       CultureInfo.InvariantCulture,
            //       DateTimeStyles.None, out projectOpenDate);

            //    if (!isValidProjectoOpenDate)
            //    {
            //        sb
            //          .AppendLine(ErrorMessage);
            //        continue;
            //    }

            //    DateTime? projectDueDate;

            //    if (!String.IsNullOrEmpty(projectsDto.DueDate) && !string.IsNullOrWhiteSpace(projectsDto.DueDate))
            //    {
            //        DateTime ValueProjectDueDate;
            //        bool isValidProjectoDueDate = DateTime.TryParseExact(projectsDto.DueDate, "MM/dd/yyyy",
            //           CultureInfo.InvariantCulture,
            //           DateTimeStyles.None, out ValueProjectDueDate);

            //        if (!isValidProjectoDueDate)
            //        {
            //            sb
            //          .AppendLine(ErrorMessage);
            //            continue;
            //        }
            //        projectDueDate = ValueProjectDueDate;
            //    }
            //    else
            //    {
            //        projectDueDate = null;
            //    }

            //    var project = new Project
            //    {
            //        Name = projectsDto.Name,
            //        OpenDate = projectOpenDate,
            //        DueDate = projectDueDate
            //    };


            //    foreach (var task in projectsDto.Tasks)
            //    {
            //        if (!IsValid(task))
            //        {
            //            sb
            //          .AppendLine(ErrorMessage);
            //            continue;
            //        }

            //        DateTime taskOpenDate;
            //        bool isValidTaskOpenDate = DateTime.TryParseExact(task.OpenDate, "MM/dd/yyyy",
            //           CultureInfo.InvariantCulture,
            //           DateTimeStyles.None, out taskOpenDate);

            //        if (!isValidTaskOpenDate)
            //        {
            //            sb
            //         .AppendLine(ErrorMessage);
            //            continue;
            //        }

            //        DateTime taskDueDate;
            //        bool isValidTaskDueDate = DateTime.TryParseExact(task.DueDate, "MM/dd/yyyy",
            //           CultureInfo.InvariantCulture,
            //           DateTimeStyles.None, out taskDueDate);

            //        if (!isValidTaskDueDate)
            //        {
            //            sb
            //        .AppendLine(ErrorMessage);
            //            continue;
            //        }

            //        if (taskOpenDate < projectOpenDate)
            //        {
            //            sb
            //         .AppendLine(ErrorMessage);
            //            continue;
            //        }

            //        if (projectDueDate.HasValue)
            //        {
            //            if (taskDueDate > projectDueDate.Value)
            //            {
            //                sb
            //                  .AppendLine(ErrorMessage);
            //                continue;
            //            }
            //        }

            //        project.Tasks.Add(new Task()
            //        {
            //            Name = task.Name,
            //            OpenDate = taskOpenDate,
            //            DueDate = taskDueDate,
            //            ExecutionType = (ExecutionType)task.ExecutionType,
            //            LabelType = (LabelType)task.LabelType,
            //            Project = project
            //        });
            //    }

            //    projects.Add(project);

            //    sb.AppendLine(String.Format(SuccessfullyImportedProject, projectsDto.Name, projectsDto.Tasks.Count()));
            //}
            //context.Projects.AddRange(projects);
            //context.SaveChanges();

            //return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {

            var sb = new StringBuilder();

            var employeeDtos = JsonConvert
                .DeserializeObject<ImportEmployeeDto[]>(jsonString);

            List<Employee> validEmpl = new List<Employee>();

            foreach (var emplDto in employeeDtos)
            {
                if (!IsValid(emplDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = emplDto.Username,
                    Email = emplDto.Email,
                    Phone = emplDto.Phone
                };

                foreach (var taskId in emplDto.Tasks.Distinct())
                {
                    Task task = context.Tasks.FirstOrDefault(t => t.Id == taskId);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        Employee = employee,
                        Task = task
                    });
                }

                validEmpl.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(validEmpl);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}