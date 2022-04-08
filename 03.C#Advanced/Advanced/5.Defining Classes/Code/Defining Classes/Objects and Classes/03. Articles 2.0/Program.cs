using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _03._Articles_2._0
{
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var list = new List<Article>();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ");

                var article = new Article(input[0], input[1], input[2]);

                list.Add(article);
            }
            string command = Console.ReadLine();

            if (command == "title")
            {
                list = list.OrderBy(x => x.Title).ToList();
            }
            else if (command == "content")
            {
                list = list.OrderBy(x => x.Content).ToList();
            }
            else if(command == "author")
            {
                list = list.OrderBy(x => x.Author).ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, list));
        }

    }
}
