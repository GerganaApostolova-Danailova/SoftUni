using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Speed_Racing
{
    public class Car
    {
        public Car(string model, decimal fuelAmount, decimal consumationPerKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.ConsumationPerKm = consumationPerKm;
            this.Distance = 0;
        }

        public string Model { get; set; }

        public decimal FuelAmount { get; set; }

        public decimal ConsumationPerKm { get; set; }

        public int Distance { get; set; }

        public void Drive(int distance)
        {
            decimal traveledDistance = distance * this.ConsumationPerKm;

            if (this.FuelAmount - traveledDistance > 0)
            {
                this.FuelAmount -= traveledDistance;
                this.Distance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }


    }
}
