using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _02._Articles
{
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Article article = new Article();

            string[] input = Console.ReadLine()
                .Split(", ");

            article.Title = input[0];
            article.Content = input[1];
            article.Author = input[2];

            int num = int.Parse(Console.ReadLine());


            for (int i = 0; i < num; i++)
            {
                string[] input2 = Console.ReadLine()
                    .Split(": ");

                string command = input2[0];
                string commandToPerforme = input2[1];


                if (command == "Edit")
                {
                    article.Content = commandToPerforme;
                }
                else if (command == "ChangeAuthor")
                {
                    article.Author = commandToPerforme;
                }
                else
                {
                    article.Title = commandToPerforme;
                }
            }

            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }
    }
}
