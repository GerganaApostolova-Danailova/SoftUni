using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _08._Vehicle_Catalogue
{
    class Program
    {
        public class Truck
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }

        }
        public class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }

        }
        public class Catalog
        {
            public List<Truck> trucks;
            public List<Car> cars;
        }

        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            catalog.trucks = new List<Truck>();
            catalog.cars = new List<Car>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] input = command
                     .Split("/");

                string tipeOfVehicle = input[0];
                string brand = input[1];
                string model = input[2];

                if (tipeOfVehicle == "Car")
                {
                    int horsePower = int.Parse(input[3]);

                    Car car = new Car();

                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = horsePower;
                    catalog.cars.Add(car);

                }
                else
                {
                    int weight = int.Parse(input[3]);

                    Truck truck = new Truck();

                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = weight;
                    catalog.trucks.Add(truck);
                }

            }
            var orderedCar = catalog.cars
                .OrderBy(x => x.Brand)
                .ToList();
            if (orderedCar.Count > 0)
            {
                Console.WriteLine("Cars:");

                foreach (var car in orderedCar)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }

            }

            var orderedTruck = catalog.trucks
                .OrderBy(x => x.Brand)
                .ToList();

            if (orderedTruck.Count > 0)
            {
                Console.WriteLine("Trucks:");

                foreach (var truck in orderedTruck)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }

            }
        }
    }

}
