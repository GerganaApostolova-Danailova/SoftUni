using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private string engineModel;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string engineModel, int power)
        {
            EngineModel = engineModel;
            Power = power;
        }

        public string EngineModel
        {
            get { return engineModel; }
            set { engineModel = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int Displacement
        {
            get { return  displacement; }
            set {  displacement = value; }
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }
    }
}
