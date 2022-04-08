using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr.Length == 1)
                {
                    Console.WriteLine("0");
                    return;
                }
                else if (arr.Length == 2 )
                {                  
                        Console.WriteLine("no");
                        return;                
                }

            }

            
                
        }
    }
}
