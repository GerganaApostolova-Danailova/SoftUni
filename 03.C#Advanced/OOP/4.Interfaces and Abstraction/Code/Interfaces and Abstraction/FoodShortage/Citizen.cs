using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IAge, IBirthable, IBuyer, IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = DateTime.ParseExact(birthday, "dd/mm/yyyy", null);
        }

        public string Name { get; }

        public int Age { get; }

        public string Id { get; }

        public DateTime Birthday { get; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
