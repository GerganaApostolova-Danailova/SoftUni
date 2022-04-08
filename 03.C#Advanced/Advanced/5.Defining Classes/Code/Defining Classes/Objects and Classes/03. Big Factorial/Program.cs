using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _03._Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            BigInteger facturiel = 1;

            for (int i = 2; i <= num; i++)
            {
                facturiel*=i;
            }

            Console.WriteLine(facturiel);
        }
    }
}
