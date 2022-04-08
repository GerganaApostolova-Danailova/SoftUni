using System;
using System.Collections.Generic;
using System.Linq;


namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            while (true)
            {
                string[] line = Console.ReadLine()
                    .Split(", ",StringSplitOptions.RemoveEmptyEntries);

                if (line[0] == "END")
                {
                    break;
                }

                string command = line[0];
                string carNumber = line[1];

                if (command == "IN")
                {
                    set.Add(carNumber);
                }
                else
                {
                    if (set.Contains(carNumber))
                    {
                        set.Remove(carNumber);
                    }
                }
            }
            if (set.Any())
            {
                foreach (var car in set)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
