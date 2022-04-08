using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double additionalConsumptionPerKm = 0.9;
        
        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        protected override double AdditionalConsumption
            => additionalConsumptionPerKm;
    }
}
