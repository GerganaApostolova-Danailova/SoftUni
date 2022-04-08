using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles.Contracts
{
    public class SpeedMotorcycle : Motorcycle
    {
        private int horsePower;

        private const int MaxHorsePower = 69;
        private const int MinHorsePower = 50;
        private const double InitializecubicCentimeters = 125;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, InitializecubicCentimeters)
        {
            this.HorsePower = horsePower;
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this.horsePower = value;
            }
        }
    }
}
