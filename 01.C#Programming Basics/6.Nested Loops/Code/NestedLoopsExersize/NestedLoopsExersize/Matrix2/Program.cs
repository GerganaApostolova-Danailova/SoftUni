using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            for (int tousends = a; tousends <= b; tousends++)
            {
                for (int hundrets = a; hundrets <= b; hundrets++)
                {
                    for (int tens = c; tens <= d; tens++)
                    {
                        for (int units = c; units <= d; units++)
                        {
                            bool equals = ((tousends!=hundrets) && (tens != units));
                            bool sum = ((tousends + units) == (hundrets + tens));

                            if (equals && sum)
                            {
                                Console.WriteLine($"{tousends}{hundrets}");
                                Console.WriteLine($"{tens}{units}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }

        }
    }
}
