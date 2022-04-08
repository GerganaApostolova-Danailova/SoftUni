using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNumber = Console.ReadLine();
            
            for (int i = inputNumber.Length - 1; i>=0; i--)
            {
                char currentDigit = inputNumber[i];
                int currentDigitToNum = int.Parse(currentDigit.ToString());

                if (currentDigitToNum == 0)
                {
                    Console.WriteLine("ZERO");
                    continue;
                }

                for (int n =1; n<= currentDigitToNum; n++)
                {
                    Console.Write( (char)(currentDigitToNum +33));
                }
                Console.WriteLine();
            }


        }
    }
}
