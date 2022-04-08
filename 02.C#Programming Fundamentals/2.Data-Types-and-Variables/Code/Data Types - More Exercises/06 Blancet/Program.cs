using System;

namespace _06_Blancet
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int openedBracket = 0;
            int closedBracket = 0;

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    openedBracket++;
                    if (openedBracket - closedBracket > 1)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }

                }
                else if (input == ")")
                {
                    closedBracket++;
                    if (openedBracket - closedBracket != 0)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                }
            }
            if (openedBracket == closedBracket)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
