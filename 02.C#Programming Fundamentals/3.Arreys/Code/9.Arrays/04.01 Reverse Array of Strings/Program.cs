using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._01_Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split();

            for (int i = elements.Length-1; i >= 0; i--)
            {
                Console.Write(elements[i]+" ");
            }
           
        }
    }
}
