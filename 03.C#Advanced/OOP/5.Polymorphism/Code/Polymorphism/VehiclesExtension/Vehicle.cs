using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
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
            this.FuelConsumption = fuelConsumption;
        }

        public double TankCapacity
        {
            get { return tankCapacity; }
            set { tankCapacity = value; }
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        protected abstract double AdditionalConsumption { get; }

        public string Drive(double distance)
        {
            double requiredFuel = (FuelConsumption + AdditionalConsumption) * distance;

            if (requiredFuel <= FuelQuantity)
            {
                FuelQuantity -= requiredFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (fuel + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }

    }
}
