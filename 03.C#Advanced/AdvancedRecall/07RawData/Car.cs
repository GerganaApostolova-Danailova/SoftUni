using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, Tire[] tires)
        {
            this.Model = model;
            this.Engine = new Engine();
            this.Cargo = new Cargo();
            this.Tires = tires;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tires { get; set; }

    }
}
