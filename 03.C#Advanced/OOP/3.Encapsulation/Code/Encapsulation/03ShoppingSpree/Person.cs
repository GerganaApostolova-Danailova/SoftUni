using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;


        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
        }


        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag 
            => this.bag.AsReadOnly();

        public void AddProduct(Product product)
        {
            if (this.money - product.Cost >= 0)
            {
                this.bag.Add(product);
                this.money -= product.Cost;

                Console.WriteLine($"{this.name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if (this.Bag.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {string.Join(", ", this.Bag.Select(x => x.Name))}";
        }
    }

}

