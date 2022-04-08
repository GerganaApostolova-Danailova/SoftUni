using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; set; }
        protected Bird(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten)
        {
            this.WingSize = wingSize;
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
