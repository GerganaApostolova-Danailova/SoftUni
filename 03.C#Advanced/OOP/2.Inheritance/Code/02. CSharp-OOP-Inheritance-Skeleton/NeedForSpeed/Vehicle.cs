using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int hp, double fuel)
        {
            HorsePower = hp;
            Fuel = fuel;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual double FuelConsumption
            => DefaultFuelConsumption;

        public void Drive(double km)
        {
            bool canDrive = this.Fuel - km * this.FuelConsumption >= 0;

            if (canDrive)
            {
                this.Fuel -= this.FuelConsumption;
            }
        }
    }
}
