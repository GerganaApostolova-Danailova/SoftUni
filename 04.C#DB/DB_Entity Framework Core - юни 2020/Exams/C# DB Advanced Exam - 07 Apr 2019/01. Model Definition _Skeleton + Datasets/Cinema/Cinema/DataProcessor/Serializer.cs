namespace Cinema.DataProcessor
{
    using System;

    using Data;

    using Cinema.XMLHelper;
    using System.Linq;
    using Cinema.Data.Models;
    using Newtonsoft.Json;
    using Cinema.DataProcessor.ExportDto;
    using System.Globalization;
    using System.Text;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.IO;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var muvies = context
                .Movies
                .ToList()
                .Where(m => m.Rating >= rating && m.Projections.Any(t => t.Tickets.Count() > 0))
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"))
                .Select(m => new
                {
                    MovieName = m.Title,
                    Rating = m.Rating.ToString("F2"),
                    TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                    Customers = m.Projections.SelectMany(p => p.Tickets).Select(c => new
                    {
                        FirstName = c.Customer.FirstName,
                        LastName = c.Customer.LastName,
                        Balance = c.Customer.Balance.ToString("F2")
                    })
                    .OrderByDescending(c => c.Balance)
                    .ThenBy(c => c.FirstName)
                    .ThenBy(c => c.LastName)
                    .ToList()
                })
                .Take(10)
                .ToArray();

            var json = JsonConvert.SerializeObject(muvies, Formatting.Indented);

            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var customersResult = context
                .Customers
                .ToList()
                .Where(c => c.Age >= age)
                .OrderByDescending(c => c.Tickets.Sum(t => t.Price).ToString("F2"))
                .Take(10)
                .Select(c => new ExportCustomerDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpentMoney = c.Tickets.Sum(t => t.Price).ToString("F2"),
                    SpentTime = TimeSpan.FromSeconds(c.Tickets.Sum(st => st.Projection.Movie.Duration.TotalSeconds)).ToString(@"hh\:mm\:ss")
                })
                .ToList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportCustomerDto>), new XmlRootAttribute("Customers"));

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(stringBuilder), customersResult, namespaces);

            return stringBuilder.ToString().TrimEnd();
        }
    }
}