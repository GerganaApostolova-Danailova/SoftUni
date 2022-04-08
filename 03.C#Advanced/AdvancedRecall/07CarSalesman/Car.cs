using System;
using System.Collections.Generic;
using System.Text;

namespace _07CarSalesman
{
    public class Car
    {
        //        •	Model: a string property.
        //•	Engine: a property holding the engine object.
        //•	Weight: an int property, it is optional.
        //•	Color: a string property, it is optional.

        private string model;
        private Engine engine;
        private string weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = "n/a";
            this.Color = "n/a";
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public string Weight
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
