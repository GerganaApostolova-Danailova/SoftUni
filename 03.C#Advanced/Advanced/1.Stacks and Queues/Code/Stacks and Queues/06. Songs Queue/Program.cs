using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vehicles = Console.ReadLine()
                .Split();

            Queue<string> vehicleForService = new Queue<string>(vehicles);

            Stack<string> servedVehicle = new Stack<string>();

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split("-");

                if (command[0] == "End")
                {
                    break;
                }
                else if (command[0] == "Service")
                {
                    if (vehicleForService.Count > 0)
                    {
                        string currentVehicleForService = vehicleForService.Dequeue();
                        servedVehicle.Push(currentVehicleForService);
                        Console.WriteLine($"Vehicle {currentVehicleForService} got served.");
                    }
                }
                else if (command[0] == "CarInfo")
                {
                    string car = command[1];

                    if (vehicleForService.Contains(car))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served");
                    }
                }
                else if (command[0] == "History" && servedVehicle.Count > 0)
                {
                    Console.WriteLine(string.Join(", ",servedVehicle));
                }
            }

            if (vehicleForService.Count > 0)
            {
                Console.WriteLine(string.Join(", ", vehicleForService));
            }
            if (servedVehicle.Count > 0)
            {
                Console.WriteLine(string.Join(", ", servedVehicle));
            }
        }
    }
}
