using System;
using System.Linq;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(", ")
                .ToArray();

            string titel = input[0];
            string content = input[1];
            string author = input[2];

            Article articl = new Article(titel, content, author);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(": ")
                    .ToArray();

                if (command[0] == "Edit")
                {
                    string newContent = command[1];

                    articl.Edit(newContent);
                }
                else if (command[0] == "ChangeAuthor")
                {
                    string newAuthor = command[1];

                    articl.ChangeAuthor(newAuthor);
                }
                else if (command[0] == "Rename")
                {
                    string newTitle = command[1];

                    articl.Rename(newTitle);
                }
            }

            Console.WriteLine(articl);
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

            public void Edit(string newContent)
            {
                this.Content = newContent;
            }

            public void ChangeAuthor(string newAuthor)
            {
                this.Author = newAuthor;
            }

            public void Rename(string newTitle)
            {
                this.Title = newTitle;
            }

            public override string ToString()
            {
                return $"{this.Title} - {this.Content}: {this.Author}";
            }
        }
    }
}
