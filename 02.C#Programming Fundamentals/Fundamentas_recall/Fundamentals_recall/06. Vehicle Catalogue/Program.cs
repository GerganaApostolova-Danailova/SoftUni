using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            List<VehicleCatalogue> vehicels = new List<VehicleCatalogue>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] currentVehicle = command.Split();

                string type = currentVehicle[0];

                if (type == "car")
                {
                    type = "Car";
                }
                else
                {
                    type = "Truck";
                }

                string model = currentVehicle[1];
                string color = currentVehicle[2];
                int horsePower = int.Parse(currentVehicle[3]);

                VehicleCatalogue vehicle = new VehicleCatalogue(type, model, color, horsePower);
                vehicels.Add(vehicle);
            }

            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                var sortedVehicle = vehicels.Where(x => x.Model == command).ToList();

                foreach (var vehicle in sortedVehicle)
                {
                    Console.WriteLine(vehicle);
                }
            }

            var sortedByCars = vehicels
                .Where(x => x.Type == "Car")
                .ToList();

            var sortedByTruck = vehicels
                .Where(x => x.Type == "Truck")
                .ToList();

            if (sortedByCars.Any())
            {
                var averageCarHorsePower = sortedByCars.Select(x => x.HorsePower).Average();
                Console.WriteLine($"Cars have average horsepower of: {averageCarHorsePower:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");

            }

            if (sortedByTruck.Any())
            {
                var averageTruckHorsePower = sortedByTruck.Select(x => x.HorsePower).Average();
                Console.WriteLine($"Trucks have average horsepower of: {averageTruckHorsePower:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }

        public class VehicleCatalogue
        {
            public VehicleCatalogue(string type, string model, string color, int horsePower)
            {
                this.Type = type;
                this.Model = model;
                this.Color = color;
                this.HorsePower = horsePower;
            }

            public string Type { get; set; }

            public string Model { get; set; }

            public string Color { get; set; }

            public int HorsePower { get; set; }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Type: {this.Type}");
                sb.AppendLine($"Model: {this.Model}");
                sb.AppendLine($"Color: {this.Color}");
                sb.AppendLine($"Horsepower: {this.HorsePower}");

                return sb.ToString().TrimEnd();
            }
        }
    }
}
