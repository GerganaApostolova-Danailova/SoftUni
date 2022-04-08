using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;

            List<Animal> animals = new List<Animal>();

            while (true)
            {
                command = Console.ReadLine();

                if (command == "Beast!")
                {
                    break;
                }

                string[] nameAgeGender = Console.ReadLine()
                    .Split();

                string name = nameAgeGender[0];
                int age = int.Parse(nameAgeGender[1]);
                string gender = nameAgeGender[2];

                try
                {
                    Animal animal = null;

                    if (command == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (command == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                    }
                    else if (command == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (command == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (command == "Tomcat")
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
