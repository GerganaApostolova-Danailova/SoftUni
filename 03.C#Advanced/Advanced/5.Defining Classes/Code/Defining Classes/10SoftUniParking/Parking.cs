using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            Capacity = capacity;
            this.cars = new List<Car>();
        }

        public int Count => this.cars.Count();

        public string AddCar(Car car)
        {
            if (this.cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }
            else if (this.cars.Count >= this.capacity)
            {
                return $"Parking is full!";
            }
            else
            {
                this.cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registration)
        {
            if (!this.cars.Any(x=>x.RegistrationNumber == registration))
            {
                return $"Car with that registration number, doesn't exist!";
            }
            else
            {
                this.cars.Remove(this.cars.FirstOrDefault(x => x.RegistrationNumber == registration));
                return $"Successfully removed {registration}";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            return this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var currentNumber in registrationNumbers)
            {
                this.cars.RemoveAll(x => x.RegistrationNumber == currentNumber);
            }
        }

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }


    }
}
