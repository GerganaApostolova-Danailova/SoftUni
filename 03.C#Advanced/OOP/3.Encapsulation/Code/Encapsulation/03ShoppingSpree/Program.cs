using System;
using System.Linq;
using System.Collections.Generic;


namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] nameAndMoney = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string[] productAndCost = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();

                for (int i = 0; i < nameAndMoney.Length; i++)
                {
                    string[] currentNama = nameAndMoney[i]
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);

                    string name = currentNama[0];
                    decimal money = decimal.Parse(currentNama[1]);

                    Person person = new Person(name, money);
                    people.Add(person);
                }

                for (int i = 0; i < productAndCost.Length; i++)
                {
                    string[] currentProduct = productAndCost[i]
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);

                    string productName = currentProduct[0];
                    decimal cost = decimal.Parse(currentProduct[1]);

                    Product product = new Product(productName, cost);
                    products.Add(product);
                }

                while (true)
                {
                    string[] input = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (input[0] == "END")
                    {
                        break;
                    }

                    string currentName = input[0];
                    string currentProduct = input[1];

                    Person person = people.FirstOrDefault(x => x.Name == currentName);
                    Product product1 = products.FirstOrDefault(x => x.Name == currentProduct);

                    person.AddProduct(product1);
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
