using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Shopping_Spree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            for (int i = 0; i < 2; i++)
            {
                string[] input = Console.ReadLine()
                        .Split('=', ';')
                        .ToArray();

                if (i == 0)
                {
                    for (int j = 0; j < input.Length - 1; j += 2)
                    {
                        string personName = input[j];
                        decimal money = decimal.Parse(input[j + 1]);

                        Person person = new Person(personName, money);
                        persons.Add(person);

                    }
                }
                if (i == 1)
                {
                    for (int k = 0; k < input.Length - 1; k += 2)
                    {
                        string productName = input[k];
                        decimal cost = decimal.Parse(input[k + 1]);

                        Product product = new Product();
                        product.Name = productName;
                        product.Cost = cost;
                        products.Add(product);
                    }
                }
            }


            string currentCommand = string.Empty;

            while ((currentCommand = Console.ReadLine()) != "END")
            {
                string[] nameAndProduct = currentCommand
                    .Split();

                string currentPersonName = nameAndProduct[0];
                string currentProductName = nameAndProduct[1];

                Product currentProduct = products.Where(x => x.Name == currentProductName).First();

                Person personByName = persons.Where(x => x.Name == currentPersonName).First();

                personByName.Bye(currentProduct, personByName);
            }

            foreach (var person in persons)
            {
                if (person.Products.Any())
                {

                    Console.WriteLine($"{person.Name} - {string.Join(", ",person.Products.Select(x=>x.Name))}");
                    
                    //for (int i = 0; i <= person.Products.Count - 1; i++)
                    //{
                    //    if (i == person.Products.Count -1)
                    //    {
                    //        Console.Write($"{person.Products[i].Name}");
                    //    }
                    //    else
                    //    {
                    //    Console.Write($"{person.Products[i].Name}, ");
                    //    }
                    //}
                    //Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
        public class Product
        {
            public string Name { get; set; }

            public decimal Cost { get; set; }
        }

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
}
