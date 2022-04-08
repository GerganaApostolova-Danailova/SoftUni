using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _06._Vehicle_Catalogue
{
    public class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }

        public Vehicle(string type, string model, string color, double horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }


        public override string ToString()

        {

            string vehicleStr = $"Type: {(this.Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +

                                $"Model: {this.Model}{Environment.NewLine}" +

                                $"Color: {this.Color}{Environment.NewLine}" +

                                $"Horsepower: {this.HorsePower}";



            return vehicleStr;

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);


                string type = command[0];
                string model = command[1];
                string color = command[2];
                double horsePower = double.Parse(command[3]);

                Vehicle currentVehicle = new Vehicle(type, model, color, horsePower);

                //currentVehicle.Type = typeOfVehicle;
                //currentVehicle.Model = model;
                //currentVehicle.Color = color;
                //currentVehicle.HorsePower = horsePower;

                vehicles.Add(currentVehicle);
            }
            List<double> carsPower = new List<double>();
            List<double> truckPower = new List<double>();

            while (true)
            {
                string model = Console.ReadLine();

                if (model == "Close the Catalogue")
                {
                    break;
                }

                Console.WriteLine(vehicles.Find(x => x.Model == model));


                foreach (var vehicle in vehicles)
                {
                    //if (vehicle.Model == model)
                    //{
                    //    if (vehicle.Type == "car")
                    //    {
                    //        Console.WriteLine("Type: Car");
                    //    }
                    //    else if (vehicle.Type == "truck")
                    //    {
                    //        Console.WriteLine("Type: Truck");
                    //    }

                    //    Console.WriteLine($"Model: {vehicle.Model}");
                    //    Console.WriteLine($"Color: {vehicle.Color}");
                    //    Console.WriteLine($"Horsepower: {vehicle.HorsePower}");
                    //}
                    if (vehicle.Type == "car")
                    {
                        carsPower.Add(vehicle.HorsePower);
                    }
                    else if (vehicle.Type == "truck")
                    {
                        truckPower.Add(vehicle.HorsePower);

                    }

                }
            }
            double averageCarPower = carsPower.Sum() / carsPower.Count;
            double averageTruckPower = truckPower.Sum() / truckPower.Count;

            if (averageCarPower > 0 )
            {
            Console.WriteLine($"Cars have average horsepower of: {averageCarPower:f2}.");
           
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
            if (averageTruckPower > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageTruckPower:f2}.");
            }
            else 
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }

        }
    }
}
