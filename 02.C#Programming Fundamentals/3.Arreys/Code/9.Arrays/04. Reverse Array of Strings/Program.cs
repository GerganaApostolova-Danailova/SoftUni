using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] texts = Console.ReadLine().Split();

            for (int i = 0; i < texts.Length/2; i++)
            {
                string furstNumber = texts[i];
                int num = texts.Length - i - 1;
                texts[i] = texts[num];
                texts[num] = furstNumber;
                //Console.Write(texts[i] + " ");
            }
            Console.WriteLine(string.Join(" ", texts));
        }
    }
}
