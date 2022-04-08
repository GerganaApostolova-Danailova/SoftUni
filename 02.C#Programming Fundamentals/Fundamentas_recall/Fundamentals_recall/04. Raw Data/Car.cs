using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Raw_Data
{
    public class Car
    {
        public Car(string model)
        {
            this.Model = model;
            this.Engine = new Engine();
            this.Cargo = new Cargo();
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }
    }
}
