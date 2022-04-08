using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int tousen = 1; tousen < 9; tousen++)
            {
                for (int hundret = 1; hundret < 9; hundret++)
                {
                    for (int tens = 1; tens < 9; tens++)
                    {
                        for (int units = 1; units < 9; units++)
                        {
                            if ((n % tousen)==0 && (n % hundret) == 0 && (n % tens) == 0 && (n % units) == 0)
                            {
                                Console.Write($"{tousen}{hundret}{tens}{units} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
