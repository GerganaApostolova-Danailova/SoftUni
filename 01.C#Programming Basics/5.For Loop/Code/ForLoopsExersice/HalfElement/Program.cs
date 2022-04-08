using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int maxNumber = int.MinValue;
            int diff = 0;

            for (int i=0; i <n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
                if ( number > maxNumber)
                {
                    maxNumber = number;
                }
                
            }
            
            if ((sum - maxNumber) == maxNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {maxNumber}");
            }
            else
            {
                diff = Math.Abs(maxNumber - (sum - maxNumber));
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
