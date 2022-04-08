using System;

namespace _06._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counter1 = 0;
            int counter2 = 0;

            for (int i = 0; i < n; i++)
            {
                string commend = Console.ReadLine();

                if (commend == "(")
                {
                    counter1++;
                }
                if (commend == ")")
                {
                    counter2++;
                }
                else
                {
                    continue;
                }
            }

            if (counter1==counter2)
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
