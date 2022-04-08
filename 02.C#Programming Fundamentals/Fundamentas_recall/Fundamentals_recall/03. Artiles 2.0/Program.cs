using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                .Split(", ")
                .ToArray();

                string titel = input[0];
                string content = input[1];
                string author = input[2];

                Article article = new Article(titel, content, author);
                articles.Add(article);
            }

            string command = Console.ReadLine();


            if (command == "title")
            {
               List<Article> sortedArthicles = articles
                    .OrderBy(x => x.Title)
                    .ToList();

                PrintSortedArticles(sortedArthicles);
            }
            else if (command == "content")
            {
                List<Article> sortedArthicles = articles
                    .OrderBy(x => x.Content)
                    .ToList();

                PrintSortedArticles(sortedArthicles);
            }
            else if (command == "author")
            {
                List<Article> sortedArthicles = articles
                    .OrderBy(x => x.Author)
                    .ToList();

                PrintSortedArticles(sortedArthicles);
            }
        }

        private static void PrintSortedArticles(List<Article> sortedArthicles)
        {
            foreach (var article in sortedArthicles)
            {
                Console.WriteLine(article);
            }
        }

        public class Article
        {
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public override string ToString()
            {
                return $"{this.Title} - {this.Content}: {this.Author}";
            }
        }
    }
}
