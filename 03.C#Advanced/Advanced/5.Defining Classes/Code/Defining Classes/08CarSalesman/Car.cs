using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string carModel;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string carModel, Engine engine)
        {
            CarModel = carModel;
            Engine = engine;
        }

        public string CarModel
        {
            get { return carModel; }
            set { carModel = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
