using System;

namespace Fundamentals_recall
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            int n = int.Parse(Console.ReadLine());

            if (n >= 1 && n <= 7)
            {
                Console.WriteLine(days[n-1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }

            //Thursday, Friday, and Saturday. Sunday
        }
    }
}
