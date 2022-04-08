using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        public string  Name { get; set; }

        public double Weight { get;  private set; }

        public int FoodEaten { get; set; }

        protected abstract double WeightInreasCoeficient { get; }

        protected abstract void ProductionSound();

        public virtual void EatFood(Food food) 
        {
            ValidateFood(food);

            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
        
        protected abstract void ValidateFood(Food food);
    }
}
