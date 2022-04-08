using System;
using System.Collections.Generic;

namespace _03._Speed_Racing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                Car car = new Car(input[0], decimal.Parse(input[1]), decimal.Parse(input[2]));

                cars.Add(car);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine())!= "End")
            {
                string[] currentCar = command.Split();

                foreach (var car in cars)
                {
                    if (car.Model == currentCar[1])
                    {
                        car.Drive(int.Parse(currentCar[2]));
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.Distance}");
            }
        }
        public class Car
        {
            public Car(string model, decimal fuelAmount, decimal consumationPerKm)
            {
                this.Model = model;
                this.FuelAmount = fuelAmount;
                this.ConsumationPerKm = consumationPerKm;
                this.Distance = 0;
            }

            public string Model { get; set; }

            public decimal FuelAmount { get; set; }

            public decimal ConsumationPerKm { get; set; }

            public int Distance { get; set; }

            public void Drive(int distance)
            {
                decimal traveledDistance = distance * this.ConsumationPerKm;

                if (this.FuelAmount - traveledDistance > 0)
                {
                    this.FuelAmount -= traveledDistance;
                    this.Distance += distance;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }


        }
    }
}
