using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                string[] peopleAndMoney = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string[] productAndCost = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

                for (int i = 0; i < peopleAndMoney.Length; i++)
                {
                    string[] commandArgs = peopleAndMoney[i]
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);

                    string personName = commandArgs[0];
                    decimal money = decimal.Parse(commandArgs[1]);

                    Person person = new Person(personName, money);
                    persons.Add(person);
                }

                for (int i = 0; i < productAndCost.Length; i++)
                {
                    string[] commandArgs = productAndCost[i]
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);

                    string productName = commandArgs[0];
                    decimal cost = decimal.Parse(commandArgs[1]);

                    Product product = new Product(productName, cost);
                    products.Add(product);
                }

                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    string[] nameAndProduct = command
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string nameOfPerson = nameAndProduct[0];
                    string nameOfProduct = nameAndProduct[1];

                    Person currentPerson = persons
                        .FirstOrDefault(persons => persons.Name == nameOfPerson);

                    Product currentProduct = products
                        .FirstOrDefault(products => products.Name == nameOfProduct);

                    currentPerson.ByeProduct(currentProduct);
                }

                foreach (var person in persons)
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
