using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string comand = string.Empty;
            int counter = 0;
            int maxConter = int.MinValue;
            int sum = 0;
            int counter1 = 0;

            while ((comand = Console.ReadLine()) != "Clone them!")
            {
                int[] arr = comand
                    .Split(new[] { '!' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int i = 0; i < n-1; i++)
                {

                    if (arr[i] == arr[i + 1] || arr [i] != 0)
                    {
                        counter++;
                       
                    }
                    if (counter > maxConter)
                    {
                        maxConter = counter;
                        sum += arr[i] + arr[i + 1];
                        counter1 = i;
                    }
                    if (arr[i] != arr[i+1] )
                    {
                        counter = 0;
                        continue;
                    }



                }

                if (comand == "Clone them!")
                {

                }
            }

        }
    }
}
