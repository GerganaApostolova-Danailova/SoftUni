using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] currentCar = Console.ReadLine()
                    .Split();

                string model = currentCar[0];
                double fuelAmount = double.Parse(currentCar[1]);
                double fuelConsumptionFor1km = double.Parse(currentCar[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km, 0);

                cars.Add(car);
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split();

                if (command[0] == "End")
                {
                    break;
                }

                string model = command[1];
                double amountOfKm = double.Parse(command[2]);

                foreach (var car in cars)
                {
                    if (car.Model == model)
                    {
                        car.Drive(car, amountOfKm);
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
