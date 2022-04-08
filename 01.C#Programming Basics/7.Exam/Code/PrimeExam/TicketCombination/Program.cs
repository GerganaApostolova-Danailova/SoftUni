using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int counter = 0;


            for (char num1 = 'B'; num1 <= 'L'; num1++)
            {
                if (num1 %2 ==0)
                    for (char num2 = 'f'; num2 >= 'a'; num2--)
                    {
                        for (char num3 = 'A'; num3 <= 'C'; num3++)
                        {
                            for (int num4 = 1; num4 <= 10; num4++)
                            {
                                for (int num5 = 10; num4 >= 1; num5--)
                                {
                                    
                                        counter++;
                                    
                                    if (counter == number)
                                    {
                                        Console.WriteLine($"Ticket combination: {num1}{num2}{num3}{num4}{num5}");
                                        Console.WriteLine($"Prize: {num1 +num2 + num3 + num4 + num5} lv.");
                                        break;
                                    
                                    }

                                }
                            }
                        }
                    }

                
            }

        }
    }
}
//int n = int.Parse(Console.ReadLine());
//int counter = 0;

//            for (char i1 = 'B'; i1 <= 'L'; i1++)
//            {
//                if (i1 % 2 == 0)
//                    for (char i2 = 'f'; i2 >= 'a'; i2--)
//                    {
//                        for (char i3 = 'A'; i3 <= 'C'; i3++)
//                        {
//                            for (int i4 = 1; i4 <= 10; i4++)
//                            {
//                                for (int i5 = 10; i5 >= 1; i5--)
//                                {

//                                    counter++;
//                                    if (counter == n)
//                                    {
//                                        Console.WriteLine($"Ticket combination: {i1}{i2}{i3}{i4}{i5}");
//                                        Console.WriteLine($"Prize: {i1 + i2 + i3 + i4 + i5} lv.");
//                                    }
//                                }
//                            }
//                        }
//                    }
//            }
