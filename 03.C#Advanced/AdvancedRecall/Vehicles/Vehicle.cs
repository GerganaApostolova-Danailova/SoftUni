using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;

            if (fuelQuantity > TankCapacity)
            {
                FuelQuantity = 0;
            }
            else
            {
                FuelQuantity = fuelQuantity;
            }

            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumptionPerKm { get; set; }

        protected abstract double AdditionalConsumption { get; }

        public double TankCapacity { get; set; }

        public string Drive(double distance)
        {
            double consumption = (this.FuelConsumptionPerKm + AdditionalConsumption) * distance;

            if (this.FuelQuantity >= consumption)
            {
                this.FuelQuantity -= consumption;

                return ($"{this.GetType().Name} travelled {distance} km");
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (FuelQuantity + fuel > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }

            this.FuelQuantity += fuel;

        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
