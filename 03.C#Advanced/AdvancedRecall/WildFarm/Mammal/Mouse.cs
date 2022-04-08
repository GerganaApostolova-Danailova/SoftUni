using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        private const double DefoultWeight = 0.10;
        public Mouse(string name, double weight, int foodEaten, string livingRegion) 
            : base(name, weight, foodEaten, livingRegion)
        {
        }

        protected override double WeightInreasCoeficient => DefoultWeight;

        protected override void ProductionSound()
        {
            Console.WriteLine("Squeak");
        }

        protected override void ValidateFood(Food food)
        {
            if (food.GetType().Name != nameof(Vegetable) || food.GetType().Name != nameof(Fruit))
            {
                this.Throw(food);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
