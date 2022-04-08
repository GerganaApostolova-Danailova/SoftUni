using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car(string model, double fuelAmount, 
            double fuelConsumptionPerKilometer, 
            double travelledDistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = travelledDistance = 0.0;
        }

        public void Drive(Car car, double amountOfKm)
        {
            double fuelExpenses = amountOfKm * car.FuelConsumptionPerKilometer;

            if (fuelExpenses > car.FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }
            else
            {
                car.TravelledDistance += amountOfKm;
                car.FuelAmount -= fuelExpenses;
            }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }



    }
}
