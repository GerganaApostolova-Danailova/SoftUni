using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] input = command.Split("/");

                string brand = input[1];
                string model = input[2];

                if (input[0] == "Car")
                {
                    int horsePower = int.Parse(input[3]);

                    Car car = new Car(brand, model, horsePower);
                    cars.Add(car);
                }
                else if (input[0] == "Truck")
                {
                    int weight = int.Parse(input[3]);

                    Truck truck = new Truck(brand, model, weight);
                    trucks.Add(truck);
                }

            }
            var orderedCars = cars
                .OrderBy(x => x.Brand)
                .ToList();

            var orderedTrucks = trucks
                .OrderBy(x => x.Brand)
                .ToList();

            Console.WriteLine("Cars:");
            foreach (var car in orderedCars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            Console.WriteLine("Trucks:");
            foreach (var truck in orderedTrucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }

        public class Car
        {
            public Car(string brand, string model, int horsePower)
            {
                this.Brand = brand;
                this.Model = model;
                this.HorsePower = horsePower;
            }

            public string Brand { get; set; }

            public string Model { get; set; }

            public int HorsePower { get; set; }
        }

        public class Truck
        {
            public Truck(string brand, string model, int weight)
            {
                this.Brand = brand;
                this.Model = model;
                this.Weight = weight;
            }

            public string Brand { get; set; }

            public string Model { get; set; }

            public int Weight { get; set; }

        }

        public class Catalog
        {
            public List<Car> Cars { get; set; }
            public List<Truck> Trucks { get; set; }
        }
    }
}
