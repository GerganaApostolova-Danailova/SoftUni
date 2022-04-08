using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int tentousens = 1; tentousens < n; tentousens++)
            {
                for (int tousen = 1; tousen < n; tousen++)
                {
                    for (int hundret = 'a'; hundret < 'a' + l; hundret++)
                    {
                        
                        for (int tens = 'a'; tens < 'a' + l; tens++)
                        {
                            for (int units = 2; units <= n; units++)
                            {
                                if (units > tentousens && units > tousen)
                                {
                                    Console.Write($"{tentousens}{tousen}{(char)hundret}{(char)tens}{units} ");
                                }
                            }   
                        }
                    }
                }
            }
        }
    }
}
