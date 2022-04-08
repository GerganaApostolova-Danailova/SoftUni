using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private int horsePower;

        private const int MaxHorsePower = 100;
        private const int MinHorsePower = 70;
        private const double InitializecubicCentimeters = 450;

        public PowerMotorcycle(string model, int horsePower)
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
