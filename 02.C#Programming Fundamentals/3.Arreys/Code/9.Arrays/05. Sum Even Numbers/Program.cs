using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                
                if(number % 2 == 0)
                {
                    sum += number;
                   
                }
            }
            Console.WriteLine(sum);
        }
    }
}
