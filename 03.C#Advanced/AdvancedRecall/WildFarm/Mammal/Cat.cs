using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        private const double DefoultWeight = 0.30;
        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        protected override double WeightInreasCoeficient => DefoultWeight;

        protected override void ProductionSound()
        {
            Console.WriteLine("Meow");
        }

        protected override void ValidateFood(Food food)
        {
            if (food.GetType().Name != nameof(Vegetable) || food.GetType().Name != nameof(Meat))
            {
                this.Throw(food);
            }
        }
    }
}
