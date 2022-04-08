using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int combination = 0;

            for (int firstNumber = 0; firstNumber <= n; firstNumber++)
            {
                for (int secondNumber = 0; secondNumber <= n; secondNumber++)
                {
                    for (int tirthNumber = 0; tirthNumber <= n; tirthNumber++)
                    {
                        for (int forthNumber = 0; forthNumber <= n; forthNumber++)
                        {
                            for (int fifthNumber = 0; fifthNumber <= n; fifthNumber++)
                            {
                                if (firstNumber+secondNumber+tirthNumber+forthNumber+fifthNumber == n)
                                {
                                    combination++;
                                }
                               
                            }
                        }
                    }

                }
            }
            Console.WriteLine(combination);
        }
    }
}
