using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = command[0];
                int speed = int.Parse(command[1]);
                int power = int.Parse(command[2]);
                int weight = int.Parse(command[3]);
                string type = command[4];
                double tire1Pressure = double.Parse(command[5]);
                int tire1Age = int.Parse(command[6]);
                double tire2Pressure = double.Parse(command[7]);
                int tire2Age = int.Parse(command[8]);
                double tire3Pressure = double.Parse(command[9]);
                int tire3Age = int.Parse(command[10]);
                double tire4Pressure = double.Parse(command[11]);
                int tire4Age = int.Parse(command[12]);

                var tires = new Tire[4]
                {
                    new Tire(tire1Pressure,tire1Age),
                    new Tire(tire2Pressure,tire2Age),
                    new Tire(tire3Pressure,tire3Age),
                    new Tire(tire4Pressure,tire4Age)
                };

                Car car = new Car(model, tires);
                car.Engine.Speed = speed;
                car.Engine.Power = power;
                car.Cargo.Weight = weight;
                car.Cargo.Type = type;

                cars.Add(car);
            }

            string typeOfCargo = Console.ReadLine();


            if (typeOfCargo == "fragile")
            {
                foreach (var car in cars)
                {
                    bool carLowPressureTire = false;

                    foreach (var tire in car.Tires)
                    {
                        if (tire.Pressure < 1)
                        {
                            carLowPressureTire = true;
                            break;
                        }
                    }
                    if (car.Cargo.Type == typeOfCargo && carLowPressureTire)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if (typeOfCargo == "flammable")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == typeOfCargo && car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
