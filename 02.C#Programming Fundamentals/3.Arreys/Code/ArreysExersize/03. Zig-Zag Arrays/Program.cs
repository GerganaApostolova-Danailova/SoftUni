using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] oddarr = new int[n];
            int[] evenarr = new int[n];

            for (int i = 1; i <= n; i++)
            {
                int[] mainarr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 1)
                {
                    oddarr[i - 1] = mainarr[0];
                    evenarr[i - 1] = mainarr[1];
                }
                else if (i % 2 == 0)
                {
                    evenarr[i-1] = mainarr[0];
                    oddarr[i - 1] = mainarr[1];
                    
                }
            }
            Console.WriteLine(string.Join(" ", oddarr));
            Console.WriteLine(string.Join(" ", evenarr));
        }
    }
}
