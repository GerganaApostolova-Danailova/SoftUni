using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50m;

        public double Coffeine { get; set; }

        public Coffee(string name, double coffeine) 
            : base(name, CoffeePrice, CoffeeMilliliters)
        {
            this.Coffeine = coffeine;
        }
    }
}
