using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;


namespace _05._HTML
{
    class Program
    {
        static void Main(string[] args)
        {

            string title = Console.ReadLine();
            string article = Console.ReadLine();

            Console.WriteLine("<h1>");
            Console.WriteLine($"    {title}");
            Console.WriteLine("</h1>");
            Console.WriteLine("<article>");
            Console.WriteLine($"    {article}");
            Console.WriteLine("</article>");



            while (true)
            {
                string comment = Console.ReadLine();

                if (comment == "end of comments")
                {
                    break;
                }

                Console.WriteLine("<div>");
                Console.WriteLine($"    {comment}");
                Console.WriteLine("</div>");

            }
        }
    }
}
