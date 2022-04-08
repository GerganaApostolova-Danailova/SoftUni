using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _7._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carPassed = int.Parse(Console.ReadLine());

            string command;
            int count = 0;
            Queue<string> passedCars = new Queue<string>();

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < carPassed; i++)
                    {
                        if (passedCars.Count > 0)
                        {
                            Console.WriteLine($"{passedCars.Dequeue()} passed!");
                            count++;

                        }

                    }
                }
                else
                {
                    passedCars.Enqueue(command);
                }
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
