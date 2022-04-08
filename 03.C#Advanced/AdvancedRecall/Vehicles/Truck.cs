using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double additionalConsumptionPerKm = 1.6;
        private const double percentOfFuelLost = 0.95;
       
        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        protected override double AdditionalConsumption
            => additionalConsumptionPerKm;

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * percentOfFuelLost);
        }
    }
}
