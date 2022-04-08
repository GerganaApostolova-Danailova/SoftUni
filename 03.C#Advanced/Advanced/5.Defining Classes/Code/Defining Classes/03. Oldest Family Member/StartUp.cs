using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfPiople = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < numberOfPiople; i++)
            {
                string[] nameAge = Console.ReadLine()
                    .Split();

                string name = nameAge[0];
                int age = int.Parse(nameAge[1]);

                Person person = new Person(name, age);


                family.AddMember(person);
            }

            var oldestMember = family.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
