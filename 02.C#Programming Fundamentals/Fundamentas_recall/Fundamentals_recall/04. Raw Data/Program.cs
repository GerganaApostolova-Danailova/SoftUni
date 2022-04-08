using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Raw_Data
{
     public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split();

                string model = command[0];
                int speed = int.Parse(command[1]);
                int power = int.Parse(command[2]);
                int weight = int.Parse(command[3]);
                string type = command[4];

                Car car = new Car(model);
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
                    if (car.Cargo.Type == typeOfCargo && car.Cargo.Weight < 1000)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if(typeOfCargo == "flamable")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == typeOfCargo && car.Engine.Power >250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
        public class Car
        {
            public Car(string model)
            {
                this.Model = model;
                this.Engine = new Engine();
                this.Cargo = new Cargo();
            }

            public string Model { get; set; }

            public Engine Engine { get; set; }

            public Cargo Cargo { get; set; }
        }
        public class Cargo
        {
            public int Weight { get; set; }

            public string Type { get; set; }
        }
        public class Engine
        {
            public int Speed { get; set; }

            public int Power { get; set; }
        }
    }
}
