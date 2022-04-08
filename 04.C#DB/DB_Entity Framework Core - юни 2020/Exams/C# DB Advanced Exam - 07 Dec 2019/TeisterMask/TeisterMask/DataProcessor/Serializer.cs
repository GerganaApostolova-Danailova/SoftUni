namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Castle.Core.Internal;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var resultBuilder = new StringBuilder();

            StringWriterWithEncoding stringWriter = new StringWriterWithEncoding(resultBuilder, Encoding.UTF8);

            var projects = context.Projects
                .Where(p => p.Tasks.Any())
                .ToArray()
                .Select(p => new ProjectExportDto
                {
                    TaskCount = p.Tasks.Count,
                    Name = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks.Select(t => new TaskExportDto
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p => p.TaskCount)
                .ThenBy(p => p.Name)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ProjectExportDto[]), new XmlRootAttribute("Projects"));
            
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(stringWriter, projects, namespaces);

            return resultBuilder.ToString().TrimEnd();
        }

        private class StringWriterWithEncoding : StringWriter
        {
            public StringWriterWithEncoding(StringBuilder sb, Encoding encoding)
                : base(sb)
            {
                this.m_Encoding = encoding;
            }
            private readonly Encoding m_Encoding;
            public override Encoding Encoding
            {
                get
                {
                    return this.m_Encoding;
                }
            }
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {

            var busyEmployees = context.Employees
                .Where(e => e.EmployeesTasks.Any(t => DateTime.Compare(date, t.Task.OpenDate) <= 0))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                             .Select(t => t.Task)
                             .Where(t => DateTime.Compare(date, t.OpenDate) <= 0)
                             .OrderByDescending(t => t.DueDate)
                             .ThenBy(t => t.Name)
                             .Select(t => new
                             {
                                 TaskName = t.Name,
                                 OpenDate = t.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                 DueDate = t.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                 LabelType = t.LabelType.ToString(),
                                 ExecutionType = t.ExecutionType.ToString()
                             })
                             .ToArray()
                })
                .ToArray()
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            var json = JsonConvert.SerializeObject(busyEmployees,Formatting.Indented);

            return json;
        }
    }
}