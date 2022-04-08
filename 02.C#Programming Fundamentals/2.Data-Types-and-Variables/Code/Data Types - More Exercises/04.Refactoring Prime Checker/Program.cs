using System;

namespace _04.Refactoring_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 2; i <= num; i++)
            {
                string prime = "true";

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        prime = "false";
                        break;
                    }


                }
                    Console.WriteLine($"{i} -> {prime}");

            }

        }
    }
}
