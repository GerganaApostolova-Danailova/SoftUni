using System;

namespace AnimalFarm.Models
{
    public class Chicken
    {
        private const string NameMassages = "Name cannot be empty.";
        private const string AgeMassages = "Age should be between 0 and 15.";

        private const int MinAge = 0;
        private const int MaxAge = 15;

        private string name;
        private int age;

        public Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullReferenceException(NameMassages);
                }
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            protected set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new Exception(AgeMassages);
                }
                this.age = value;
            }
        }

        public double CalculateProductPerDay()
        {
            if (this.Age <= 3)
            {
                return 1.5;
            }
            else if (this.Age <= 7)
            {
                return 2;
            }
            else if (this.Age <= 11)
            {
                return 1;
            }

            return 0.75;
        }

        public override string ToString()
        {
            return $"Chicken {this.Name} (age {this.Age}) can produce" +
                $" {this.CalculateProductPerDay()} eggs per day.";
        }
    }
}
