using System;

namespace _18_December_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int spirit = 0;
            double cost = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 10 == 0)
                {
                    if (days == i)
                    {
                        spirit -= 30;
                    }

                    spirit -= 20;
                    cost += (5 + 3 + 15);

                }
                if (i % 11 == 0)
                {
                    quantity += 2;
                }
                if (i % 5 == 0)
                {
                    cost += quantity * 15;
                    spirit += 17;

                    if (i % 3 == 0)
                    {
                        spirit += 30;
                    }
                }
                if (i % 3 == 0)
                {
                    cost += quantity * 5;
                    cost += quantity * 3;
                    spirit += 13;
                }
                if (i % 2 == 0)
                {
                    cost += quantity * 2;
                    spirit += 5;
                }

            }
            
            Console.WriteLine($"Total cost: {cost}");
            Console.WriteLine($"Total spirit: {spirit}");
        }
    }
}
