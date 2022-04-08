using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for ( int fursNumber = 1; fursNumber <= 9; fursNumber++)
            {
                for (int secondNumber = 1; secondNumber <= 9; secondNumber++)
                {
                    for (int thurthNumber = 1; thurthNumber <= 9; thurthNumber++)
                    {
                        for (int fourNumber = 1; fourNumber <= 9; fourNumber++)
                        {
                            for (int fifthsNumber = 1; fifthsNumber <= 9; fifthsNumber++)
                            {
                                for (int sixthNumber = 1; sixthNumber <= 9; sixthNumber++)
                                {
                                    int current = fursNumber * secondNumber * thurthNumber * fourNumber * fifthsNumber * sixthNumber;
                                    if (current == number) 
                                    {
                                        Console.Write($"{fursNumber}{secondNumber}{thurthNumber}{fourNumber}{fifthsNumber}{sixthNumber} ");
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
    }
}
