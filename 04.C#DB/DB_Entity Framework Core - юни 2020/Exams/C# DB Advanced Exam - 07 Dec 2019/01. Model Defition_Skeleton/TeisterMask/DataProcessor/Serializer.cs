namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using TeisterMask.XMLHelper;
    using System.IO;
    using Formatting = Newtonsoft.Json.Formatting;
    using System.Collections.Generic;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .Where(p => p.Tasks.Count > 0)
                .AsEnumerable()
                .Select(p => new ExportProjectDto
                {
                    TasksCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = p.Tasks.Select(t => new ExportTaskDto
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToList();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(List<ExportProjectDto>), new XmlRootAttribute("Projects"));

            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            using (var sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, projects, nameSpaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context
                 .Employees
                 .ToArray()
                 .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                 .Select(e => new
                 {
                     Username = e.Username,
                     Tasks = e.EmployeesTasks
                     .Where(et=>et.Task.OpenDate >= date)
                     .OrderByDescending(et=>et.Task.DueDate)
                     .ThenBy(et=>et.Task.Name)
                     .Select(t => new
                     {
                         TaskName = t.Task.Name,
                         OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                         DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                         LabelType = t.Task.LabelType.ToString(),
                         ExecutionType = t.Task.ExecutionType.ToString()
                     })
                     .ToArray()
                 })
                 .OrderByDescending(e => e.Tasks.Count())
                 .ThenBy(e => e.Username)
                 .Take(10)
                 .ToArray();

            var json = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return json;
        }
    }
}