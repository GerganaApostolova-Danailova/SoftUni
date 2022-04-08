using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Common_Elements_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine()
                .Split()
                .ToArray();

            string[] arr2 = Console.ReadLine()
                .Split()
                .ToArray();

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        Console.WriteLine($"{arr1[i]} ");
                    }
                }
                
            }
        }
    }
}
