using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int evenSum = 0;
            int oddSum = 0;


            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                
                if (currentNumber % 2 == 0)
                {
                    evenSum += currentNumber;
                }
                else
                {
                    oddSum += currentNumber;
                }
            }

            int differens = evenSum - oddSum;

            Console.WriteLine(differens);
        }
    }
}
