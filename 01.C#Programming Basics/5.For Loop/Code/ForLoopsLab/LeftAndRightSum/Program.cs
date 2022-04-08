using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumRight = 0;
            int sumLeft = 0;
            int diff = 0;

            for (int i=0; i<n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                sumRight += num;

            }

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                sumLeft += num;

            }

            if (sumLeft == sumRight)
            {
                Console.WriteLine($"Yes, sum = {sumLeft}");
            }
            else
            {
                diff = Math.Abs(sumLeft - sumRight);
                Console.WriteLine($"No, diff = {diff}");
            }
        }
    }
}
