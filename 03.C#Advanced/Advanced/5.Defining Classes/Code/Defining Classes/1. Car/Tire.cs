using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        private int year;
        private double presssure;

        public int Year { get; set; }
        public double Presssure { get; set; }

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Presssure = pressure;
        }

    }
}
