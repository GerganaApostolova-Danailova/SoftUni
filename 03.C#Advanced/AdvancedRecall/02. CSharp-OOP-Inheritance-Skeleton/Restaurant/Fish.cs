using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Fish : MainDish
    {
        //•	Grams = 22

        private const double DefoultGrams = 22;
        public Fish(string name, decimal price)
            : base(name, price, DefoultGrams)
        {

        }
    }
}
