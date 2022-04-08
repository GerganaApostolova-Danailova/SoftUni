namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore.Migrations.Operations;
    using System;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //string input = Console.ReadLine();

            //int input = int.Parse(Console.ReadLine());

            int result = RemoveBooks(db);

            //string result = IncreasePrices(db);
            //IncreasePrices(db);

            Console.WriteLine(result);
        }

        //Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            var bookByAgeRestriction = context
                .Books
                .ToList()
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var result = string.Join(Environment.NewLine, bookByAgeRestriction);

            return result;
        }

        //Prolem 03

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context
                .Books
                .ToList()
                .Where(b => b.EditionType.ToString() == "Gold" && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        //Problem 04

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksByPrice = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToList();

            foreach (var b in booksByPrice)
            {
                sb
                    .AppendLine($"{b.Title} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
            
        }

        //Problem 05

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var bookInGivenYear = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, bookInGivenYear);

            return result;
        }

        //Problem 06

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] category = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToString().ToLower())
                .ToArray();

            var booksByCategory = context
                .Books
                .Where(b => b.BookCategories
                .Any(bc => category.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(bt => bt)
                .ToList();

            var result = string.Join(Environment.NewLine, booksByCategory);

            return result;
        }

        //Problem 07

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var relisedBooks = context
                .Books
                .Where(b => b.ReleaseDate < releaseDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new { b.Title, b.EditionType, b.Price })
                .ToList();

            return String.Join(Environment.NewLine, relisedBooks
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}"));
        }

        //Problem 08

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorName = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    fullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.fullName)
                .ToList();

            return String.Join(Environment.NewLine, authorName
                .Select( a => $"{a.fullName}"));

        }

        //Problem 09

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        //Problem 10

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {

            StringBuilder sb = new StringBuilder();
            var books = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    fullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            foreach (var b in books)
            {
                sb
                    .AppendLine($"{b.Title} ({b.fullName})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 11

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {

           return context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

        }

        //Problem 12

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var bookCopies = context
                .Authors
                .Select(a => new
                {
                    fullName = a.FirstName + " " + a.LastName,
                    booksCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.booksCopies)
                .ToList();

            foreach (var a in bookCopies)
            {
                sb
                    .AppendLine($"{a.fullName} - {a.booksCopies}");
            }

            return sb.ToString().TrimEnd();
                
        }

        //Problem 13

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var catecoryPrice = context
                .Categories
                .Select(c => new
                {
                    name = c.Name,
                    TotalProfit = c.CategoryBooks
                    .Select(cb => new
                    {
                        BookProfit = cb.Book.Copies * cb.Book.Price
                    })
                    .Sum(cb =>cb.BookProfit)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.name)
                .ToList();

            foreach (var a in catecoryPrice)
            {
                sb
                    .AppendLine($"{a.name} ${a.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();

        }

        //Problem 14

        public static string GetMostRecentBooks(BookShopContext context)
        {

            StringBuilder sb = new StringBuilder();

            var mostResentBooks = context
                .Categories
                .Select(c => new
                {
                    categoryName = c.Name,
                    recentBooks = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Take(3)
                    .Select(cb => new
                    {
                        bookName = cb.Book.Title,
                        bookYear = cb.Book.ReleaseDate.Value.Year
                    })
                    .ToList()
                })
                .OrderBy(c => c.categoryName)
                .ToList();

            foreach (var m in mostResentBooks)
            {
                sb
                    .AppendLine($"--{m.categoryName}");
                foreach (var rb in m.recentBooks)
                {
                    sb
                        .AppendLine($"{rb.bookName} ({rb.bookYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 15

        public static void IncreasePrices(BookShopContext context)
        {
            var increase = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var b in increase)
            {
                b.Price += 5;
            }

            context.SaveChanges();
        }

        //Problem 16

        public static int RemoveBooks(BookShopContext context)
        {
            var remuvedBook = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.RemoveRange(remuvedBook);
            context.SaveChanges();

            return remuvedBook.Count();
        }
    }
}
