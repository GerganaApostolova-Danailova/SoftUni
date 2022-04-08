using System;

namespace Problem_1._Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int partners = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int money = days * 50;

            for (int i = 1; i <= days; i++)
            {
                
                if (i % 10 == 0)
                {
                    partners -= 2;
                }
                if (i % 15 == 0)
                {
                    partners += 5;
                }
                if (i % 3 == 0)
                {
                    money -= partners * 3;
                }
                if (i % 5 == 0)
                {
                    money += partners * 20;

                    if (i % 3 == 0)
                    {
                        money -= partners * 2;
                    }
                }

                money -= partners * 2;
            }
            
                int result = money / partners;

            Console.WriteLine($"{partners} companions received {result} coins each.");
        }
    }
}
