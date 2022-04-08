using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();


            string[] splitedinput = input
                .Split(new char[] {' ', '\t'},StringSplitOptions.RemoveEmptyEntries);


            double sum = 0;
           


            for (int i = 0; i < splitedinput.Length; i++)
            {
                string currentInput = splitedinput[i];
                char firstLetter = currentInput[0];
                char lastLetter = currentInput[currentInput.Length - 1];
                double digit = int.Parse(currentInput.Substring(1, currentInput.Length - 2));

                if (char.IsUpper(firstLetter))
                {
                    digit /= firstLetter - 'A' + 1;
                }
                else
                {
                    digit *= firstLetter - 'a' + 1;
                }
                if (char.IsUpper(lastLetter))
                {
                    digit -= lastLetter - 'A' + 1;
                }
                else
                {
                    digit += lastLetter - 'a' + 1;
                }

                sum += digit;
                
            }

            Console.WriteLine(sum.ToString("f2"));
        }
    }
}
