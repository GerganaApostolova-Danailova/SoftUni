using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Beast!")
                {
                    break;
                }

                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string name = arguments[0];

                    if (!int.TryParse(arguments[1], out int age))
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    string gender = String.Empty;

                    if (arguments.Length == 3)
                    {
                        gender = arguments[2];
                    }

                    Animal animal = null;

                    input = input.ToLower();

                    if (input == "dog")
                    {
                        animal = new Dog(name, age, gender);
                    }
                    else if (input == "cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (input == "frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (input == "kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (input == "tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    if (animal != null)
                    {
                        animals.Add(animal);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
