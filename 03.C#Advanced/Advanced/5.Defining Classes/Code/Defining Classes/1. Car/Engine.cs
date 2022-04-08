using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
     public class Engine
    {
        private int horsePower;
        private double cubicCapacity;


        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCpacity = cubicCapacity;
        }

        public int HorsePower { get; set; }
        public double CubicCpacity { get; set; }

    }
}
