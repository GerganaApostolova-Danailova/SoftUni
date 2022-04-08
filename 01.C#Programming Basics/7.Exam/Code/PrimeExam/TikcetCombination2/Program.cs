using System;

namespace _06.TicketCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            for (char i1 = 'B'; i1 <= 'L'; i1++)
            {
                if (i1 % 2 == 0)
                    for (char i2 = 'f'; i2 >= 'a'; i2--)
                    {
                        for (char i3 = 'A'; i3 <= 'C'; i3++)
                        {
                            for (int i4 = 1; i4 <= 10; i4++)
                            {
                                for (int i5 = 10; i5 >= 1; i5--)
                                {

                                    counter++;
                                    if (counter == n)
                                    {
                                        Console.WriteLine($"Ticket combination: {i1}{i2}{i3}{i4}{i5}");
                                        Console.WriteLine($"Prize: {i1 + i2 + i3 + i4 + i5} lv.");
                                    }
                                }
                            }
                        }
                    }
            }
        }
    }
}