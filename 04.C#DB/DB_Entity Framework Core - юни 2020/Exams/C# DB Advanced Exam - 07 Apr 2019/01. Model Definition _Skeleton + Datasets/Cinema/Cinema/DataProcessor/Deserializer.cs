namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using Cinema.XMLHelper;
    using System.Globalization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDto = JsonConvert
                .DeserializeObject<ImportMuviesDto[]>(jsonString);

            var sb = new StringBuilder();

            var movies = new List<Movie>();

            foreach (var m in moviesDto)
            {
                if (!IsValid(m))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (String.IsNullOrEmpty(m.Genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Genre genre;
                var validGenre = Enum.TryParse<Genre>(m.Genre.ToString(), out genre);

                if (!validGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isExistTitle = movies
                    .FirstOrDefault(x => x.Title == m.Title) != null;

                if (isExistTitle)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = m.Title,
                    Genre = genre,
                    Duration = m.Duration,
                    Rating = m.Rating,
                    Director = m.Director
                };

                movies.Add(movie);
                sb.AppendLine(String.Format(SuccessfulImportMovie, m.Title, genre, m.Rating.ToString("F2")));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallDto = JsonConvert
                .DeserializeObject<ImportHallAndSeatsDto[]>(jsonString);

            var sb = new StringBuilder();

            var halls = new List<Hall>();

            foreach (var hallSeatDto in hallDto)
            {
                if (!IsValid(hallSeatDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallSeatDto.Name,
                    Is3D = hallSeatDto.Is3D,
                    Is4Dx = hallSeatDto.Is4Dx,
                };

                for (int i = 0; i < hallSeatDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                halls.Add(hall);

                string status = "";

                if (hall.Is4Dx)
                {
                    status = hall.Is3D ? "4Dx/3D" : "4Dx";
                }
                else if (hall.Is3D)
                {
                    status = "3D";
                }
                else
                {
                    status = "Normal";
                }

                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, status, hall.Seats.Count));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlResult = XmlConverter
                .Deserializer<ImportProjectionDto>(xmlString, "Projections");

            StringBuilder sb = new StringBuilder();

            var projections = new List<Projection>();

            foreach (var prDto in xmlResult)
            {
                var movie = context.Movies.Find(prDto.MovieId);
                var hall = context.Halls.Find(prDto.HallId);

                if (movie == null || hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = prDto.MovieId,
                    HallId = prDto.HallId,
                    DateTime = DateTime
                    .ParseExact(prDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projections.Add(projection);

                sb.AppendLine(string.Format(SuccessfulImportProjection, movie.Title, projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlResult = XmlConverter
                .Deserializer<ImportCustomerTicketsDto>(xmlString, "Customers");
            
            var sb = new StringBuilder();

            var customers = new List<Customer>();

            foreach (var customerDto in xmlResult)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance
                };

                foreach (var ticketDto in customerDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var projection = context.Projections.Find(ticketDto.ProjectionId);

                    if (projection == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    customer.Tickets.Add(new Ticket
                    {
                        ProjectionId = ticketDto.ProjectionId,
                        Price = ticketDto.Price
                    });
                }

                customers.Add(customer);

                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket,customerDto.FirstName, customerDto.LastName, customerDto.Tickets.Count()));
            }

            context.Customers.AddRange(customers);
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