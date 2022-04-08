using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual double FuelConsumption => DefaultFuelConsumption;
       
        public virtual void Drive(double kilometers)
        {
            if (this.Fuel-(kilometers * this.FuelConsumption) >= 0)
            {
                this.Fuel -= kilometers * this.FuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enaugh fuel to this travel distance!");
            }
        }
    }
}
