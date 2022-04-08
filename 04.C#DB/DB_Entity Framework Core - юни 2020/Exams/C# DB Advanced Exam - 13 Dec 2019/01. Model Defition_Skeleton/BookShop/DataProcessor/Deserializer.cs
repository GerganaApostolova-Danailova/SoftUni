namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ProductShop.XMLHelper;
    using Data.Models.Enums;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var xmlResult = XmlConverter.Deserializer<ImportBookDto>(xmlString, "Books");

            var bookToAdd = new List<Book>();
            var sb = new StringBuilder();

            foreach (ImportBookDto bookDto in xmlResult)
            {
                if (!IsValid(bookDto))
                {
                    sb
                        .AppendLine(ErrorMessage);
                    continue;
                }

                DateTime publishedOn;
                bool isDateValid = DateTime.TryParseExact(bookDto.PublishedOn, "MM/dd/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out publishedOn);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newBook = new Book
                {
                    Name = bookDto.Name,
                    Genre = (Genre)bookDto.Genre,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    PublishedOn = publishedOn
                };

                bookToAdd.Add(newBook);
                sb
                    .AppendLine(String.Format(SuccessfullyImportedBook, bookDto.Name, bookDto.Price));
            }

            context.Books.AddRange(bookToAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorDtos = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Author> authors = new List<Author>();

            foreach (var authorDto in authorDtos)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool doesEmailExists = authors
                    .FirstOrDefault(x => x.Email == authorDto.Email) != null;

                if (doesEmailExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone
                };

                var uniqueBookIds = authorDto.Books.Distinct();

                foreach (var authorDtoAuthorBookDto in uniqueBookIds)
                {
                    var book = context.Books.Find(authorDtoAuthorBookDto.BookId);

                    if (book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book
                    });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, (author.FirstName + " " + author.LastName), author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}