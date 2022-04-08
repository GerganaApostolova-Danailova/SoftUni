using System;
using System.Collections.Generic;
using System.Linq;


namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCar = int.Parse(Console.ReadLine());

            Dictionary<string, string> carsInParking = new Dictionary<string, string>();

            for (int i = 0; i < numCar; i++)
            {
                List<string> registers = Console.ReadLine()
                    .Split()
                    .ToList();

                string reg = registers[0];
                string name = registers[1];

                if (reg == "unregister")
                {
                    if (carsInParking.ContainsKey(name))
                    {
                        carsInParking.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                }
                else if (reg == "register")
                {
                    string numberOfCar = registers[2];

                    if (carsInParking.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {numberOfCar}");
                    }
                    else
                    {
                        carsInParking.Add(name, numberOfCar);
                        Console.WriteLine($"{name} registered {numberOfCar} successfully");
                    }
                }
            }

            foreach (var car in carsInParking)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
    }
}
