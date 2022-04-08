using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int engineNumber = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < engineNumber; i++)
            {
                string[] engineLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string engineModel = engineLine[0];
                int power = int.Parse(engineLine[1]);

                Engine engine = new Engine(engineModel, power);

                if (engineLine.Length == 3)
                {
                    int displacement;

                    if (int.TryParse(engineLine[2], out displacement))
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = engineLine[2];
                    }
                }
                if (engineLine.Length == 4)
                {
                    int displacement = int.Parse(engineLine[2]);
                    string efficiency = engineLine[3];

                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }

                engines.Add(engine);
            }

            int carNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < carNumber; i++)
            {
                string[] carLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = carLine[0];
                string engine = carLine[1];

                Engine currentEngine = engines.FirstOrDefault(e => e.EngineModel == engine);

                Car car = new Car(carModel, currentEngine);

                if (carLine.Length == 3)
                {
                    int weight;

                    if (int.TryParse(carLine[2], out weight))
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = carLine[2];
                    }
                }
     
                if (carLine.Length == 4)
                {
                    int weight = int.Parse(carLine[2]);
                    string color = carLine[3];

                    car.Weight = weight;
                    car.Color = color;
                }

                cars.Add(car);
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.CarModel}:");

                Console.WriteLine($"  {car.Engine.EngineModel}:");

                Console.WriteLine($"    Power: {car.Engine.Power}");

                if (car.Engine.Displacement == 0)
                {
                    Console.WriteLine("    Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }
                if (car.Engine.Efficiency == null)
                {
                    Console.WriteLine("    Efficiency: n/a");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                }
                if (car.Weight == 0)
                {
                    Console.WriteLine("  Weight: n/a");
                }
                else
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }
                if (car.Color == null)
                {
                    Console.WriteLine("  Color: n/a");
                }
                else
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }
            }
        }
    }
}
