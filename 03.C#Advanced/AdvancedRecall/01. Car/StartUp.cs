using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "No more tires")
                {
                    break;
                }

                double[] currentTire = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();


                var currentTires = new Tire[4]
                {
                    new Tire((int)currentTire[0], currentTire[1]),
                    new Tire((int)currentTire[2], currentTire[3]),
                    new Tire((int)currentTire[4], currentTire[5]),
                    new Tire((int)currentTire[6], currentTire[7]),
                };
                //int count = 0;

                //for (int i = 0; i < currentTire.Length; i += 2)
                //{
                //    int yearOfTires = int.Parse(currentTire[i]);
                //    double pressureOfTires = double.Parse(currentTire[i + 1]);
                //    currentTires[count] = new Tire(yearOfTires, pressureOfTires);
                //    count++;
                //}

                tires.Add(currentTires);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Engines done")
                {
                    break;
                }

                double[] currentEngine = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                Engine engine = new Engine((int)currentEngine[0], currentEngine[1]);

                engines.Add(engine);

            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Show special")
                {
                    break;
                }

                string[] currentCar = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string make = currentCar[0];
                string model = currentCar[1];
                int year = int.Parse(currentCar[2]);
                double fuelQuantity = double.Parse(currentCar[3]);
                double fuelConsumption = double.Parse(currentCar[4]);
                int engineIndex = int.Parse(currentCar[5]);
                int tiresIndex = int.Parse(currentCar[6]);

                Engine engine = engines[engineIndex];
                Tire[] tire = tires[tiresIndex];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tire);

                cars.Add(car);

            }

            var specialCars = cars
                 .Where(x => x.Year >= 2017)
                 .Where(x => x.Engine.HorsePower > 330)
                 .Where((x,p) => x.Tires.Sum(p=>p.Pressure) >= 9 && x.Tires.Sum(p=>p.Pressure) <= 10)
                 .ToList();

            foreach (var car in specialCars)
            {
                car.Drive(20);

                Console.WriteLine(car.WhoAmI());
            }
            //foreach (var car in cars)
            //{
            //    bool chackYear = car.Year >= 2017;
            //    bool checkHorcePower = car.Engine.HorsePower >= 330;
            //    double sumOfPressure = 0.0;

            //    foreach (var tire in car.Tires)
            //    {
            //        sumOfPressure += tire.Pressure;

            //    }
            //    bool checkPressure = sumOfPressure >= 9 && sumOfPressure <= 10;

            //    if (checkHorcePower && checkPressure && chackYear)
            //    {
            //        car.Drive(20);

            //        Console.WriteLine(car.WhoAmI());
            //    }
            //}


            //foreach (var car in specialCars)
            //{
            //    car.Drive(20);

            //    Console.WriteLine(car);
            //}

            //var tires = new Tire[4]
            //{
            //    new Tire(1,2.5),
            //    new Tire(1,2.1),
            //    new Tire(2,0.5),
            //    new Tire(2,2.3),

            //};

            //Engine engine = new Engine(560, 6300);

            //var car = new Car("Trabant", "Gosho", 1980, 250, 9, engine, tires);

            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumtion = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumtion);
            //Car car = new Car();

            //car.Make = "Toyota";
            //car.Model = "Yaris";
            //car.Year = 2006;
            //car.FuelQuantity = 200;
            //car.FuelConsumption = 200;
            //car.Drive(1000);
            //Console.WriteLine(car.WhoAmI());

            // Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}
