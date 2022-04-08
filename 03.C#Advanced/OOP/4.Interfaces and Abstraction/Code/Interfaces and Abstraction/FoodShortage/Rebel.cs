using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IBuyer, IAge
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get; }

        public int Age { get; }

        public string Group { get; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
