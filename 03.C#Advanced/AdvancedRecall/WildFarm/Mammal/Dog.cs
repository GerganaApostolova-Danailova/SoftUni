using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        private const double DefoultWeight = 0.40;
        public Dog(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten, livingRegion)
        {
        }

        protected override double WeightInreasCoeficient => throw new NotImplementedException();

        protected override void ProductionSound()
        {
            Console.WriteLine("Woof!");
        }

        protected override void ValidateFood(Food food)
        {
            if (food.GetType().Name != nameof(Meat))
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
