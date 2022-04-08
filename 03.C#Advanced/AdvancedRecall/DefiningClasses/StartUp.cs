using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numofPeople = int.Parse(Console.ReadLine());

            //Family family = new Family();

            List<Person> persons = new List<Person>();

            for (int i = 0; i < numofPeople; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = command[0];
                int age = int.Parse(command[1]);

                Person person = new Person(name,age);

                persons.Add(person);

            }
            List<Person> peopleOver30Age = persons
             .Where(x => x.Age > 30)
             .OrderBy(x => x.Name)
             .ToList();

            foreach (Person person in peopleOver30Age)
            {
                Console.WriteLine(person);
            }
        }
    }
}
