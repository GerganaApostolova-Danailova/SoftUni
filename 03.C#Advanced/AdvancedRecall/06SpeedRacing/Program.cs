using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int carNumber = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < carNumber; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = command[0];
                double fuelAmount = double.Parse(command[1]);
                double fuelConsumptionFor1km = double.Parse(command[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

                cars.Add(car);
            }

            while (true)
            {
                string drivingCar = Console.ReadLine();

                if (drivingCar == "End")
                {
                    break;
                }

                string[] currentCar = drivingCar
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = currentCar[1];
                double distance = double.Parse(currentCar[2]);

                Car carByModel = cars
                    .Where(x => x.Model == model)
                    .FirstOrDefault();

                if (carByModel != null)
                {
                    carByModel.Drive(distance);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
