﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUmberOneToHundred
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i= n; i>0; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}