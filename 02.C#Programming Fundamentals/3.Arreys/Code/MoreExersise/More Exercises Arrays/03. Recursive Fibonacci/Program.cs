using System;
using System.Collections.Generic;

namespace _03._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            double[] arr = new double[num];

            if (arr.Length == 1)
            {
                arr[0] = 1;
                Console.WriteLine(arr[0]);
                return;
            }
            if (arr.Length == 2)
            {
                arr[0] = 1;
                arr[1] = 1;

                Console.WriteLine(arr[1]);
                return;

            }

                for (int i = 2; i < num; i++)
                {


                    arr[0] = 1;
                    arr[1] = 1;
                    arr[i] = arr[i - 2] + arr[i - 1];


                }
                Console.WriteLine(arr[arr.Length - 1]);
            }
        }
    }
