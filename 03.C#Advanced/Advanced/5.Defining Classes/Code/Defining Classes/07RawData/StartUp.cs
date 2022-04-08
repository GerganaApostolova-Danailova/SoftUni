using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> collectionOfCars = new List<Car>();

            //Dictionary<string, Car> collectionOfCars = new Dictionary<string, Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] currentCar = Console.ReadLine()
                    .Split();

                string model = currentCar[0];

                int engineSpeed = int.Parse(currentCar[1]);
                int enginePower = int.Parse(currentCar[2]);

                int cargoWeight = int.Parse(currentCar[3]);
                string cargoType = currentCar[4];

                Tire[] tires = new Tire[4];
                int counter = 0;

                for (int tireIndex = 5; tireIndex < currentCar.Length; tireIndex += 2)
                {
                    double tirePressure = double.Parse(currentCar[tireIndex]);
                    int tireAge = int.Parse(currentCar[tireIndex + 1]);

                    Tire tire = new Tire(tirePressure, tireAge);
                    tires[counter] = tire;
                    counter++;
                }

                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Engine engine = new Engine(engineSpeed, enginePower);
                Car car = new Car(model, engine, cargo, tires);
                collectionOfCars.Add(car);
            }

            ;

            string line = Console.ReadLine();

            if (line == "fragile")
            {
                foreach (var car in collectionOfCars)
                {
                    if (car.Cargo.CargoType == "fragile")
                    {
                        bool isLowerPressure = false;

                        foreach (var pressure in car.Tires)
                        {
                            if (pressure.TirePressur < 1)
                            {
                                isLowerPressure = true;
                            }
                        }
                        if (isLowerPressure)
                        {
                            Console.WriteLine($"{car.Model}");
                        }
                    }
                }
            }
            else if (line == "flamable")
            {
                foreach (var car in collectionOfCars)
                {
                    if (car.Cargo.CargoType == "flamable")
                    {
                        if (car.Engine.EnginePower > 250)
                        {
                            Console.WriteLine($"{car.Model}");
                        }
                    }
                }
            }

        }
    }
}
