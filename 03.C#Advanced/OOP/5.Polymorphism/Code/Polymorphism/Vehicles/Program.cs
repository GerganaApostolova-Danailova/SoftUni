using System;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine()
                .Split();

            string[] truckInput = Console.ReadLine()
                .Split();

            double CarFuelCuantity = double.Parse(carInput[1]);
            double CarFuelConsumption = double.Parse(carInput[2]);

            Vehicle car = new Car(CarFuelCuantity, CarFuelConsumption);

            double TruckFuelCuantity = double.Parse(truckInput[1]);
            double TruckFuelConsumption = double.Parse(truckInput[2]);

            Vehicle truck = new Truck(TruckFuelCuantity, TruckFuelConsumption);

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] drivingCurrentVehicle = Console.ReadLine()
                    .Split();

                string move = drivingCurrentVehicle[0];
                string vehicle = drivingCurrentVehicle[1];

                if (move == "Drive")
                {
                    double distance = double.Parse(drivingCurrentVehicle[2]);

                    if (vehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(distance)); 
                    }
                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                }
                else if (move == "Refuel")
                {
                    double fuel = double.Parse(drivingCurrentVehicle[2]);

                    if (vehicle == "Car")
                    {
                        car.Refuel(fuel);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(fuel);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);

        }
    }
}
