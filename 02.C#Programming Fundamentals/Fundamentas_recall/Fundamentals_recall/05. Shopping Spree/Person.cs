using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Shopping_Spree
{
    public class Person
    {
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
        }

        public string Name { get; set; }

        public decimal Money { get; set; }

        public List<Product> Products { get; set; }

        public void Bye(Product product, Person person)
        {
            if (person.Money - product.Cost >= 0)
            {
                person.Money -= product.Cost;
                person.Products.Add(product);
                Console.WriteLine($"{person.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }
        }
    }
}
