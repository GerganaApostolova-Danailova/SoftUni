using System;
using System.Collections.Generic;
using System.Linq;


namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfPiople = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();


            for (int i = 0; i < numberOfPiople; i++)
            {
                string[] nameAge = Console.ReadLine()
                    .Split();

                string name = nameAge[0];
                int age = int.Parse(nameAge[1]);

                Person person = new Person(name, age);

                persons.Add(person);
            }

            var sortedPersons = persons
                .Where(a => a.Age > 30)
                .OrderBy(n => n.Name)
                .ToList();

            foreach (var person in sortedPersons)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
