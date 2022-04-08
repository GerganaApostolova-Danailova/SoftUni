using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        private const double DefoultWeight = 1.00;
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        protected override double WeightInreasCoeficient => DefoultWeight;

        protected override void ProductionSound()
        {
            Console.WriteLine("ROAR!!!");
        }

        protected override void ValidateFood(Food food)
        {
            if (food.GetType().Name != nameof(Meat))
            {
                this.Throw(food);
            }
        }
    }
}
