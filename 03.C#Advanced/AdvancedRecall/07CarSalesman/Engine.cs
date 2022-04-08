﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07CarSalesman
{
    public class Engine
    {
        //Model: a string property.
        //•	Power: an int property.
        //•	Displacement: an int property, it is optional.
        //•	Efficiency: a string property, it is optional.

        private string model;
        private int power;
        private string displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = "n / a";
            this.Efficiency = "n / a";
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public string Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }
    }
}
s