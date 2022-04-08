using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        private const double DefoultWeight = 0.25;
        public Owl(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }

        protected override double WeightInreasCoeficient => DefoultWeight;

        protected override void ProductionSound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        protected override void ValidateFood(Food food)
        {
            
        }
    }
}
