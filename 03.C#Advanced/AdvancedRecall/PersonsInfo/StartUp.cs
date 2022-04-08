using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();
            Team team = new Team("SoftUni");


            for (int i = 0; i < lines; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split();
                try
                {
                    Person person = new Person(commandArgs[0], 
                        commandArgs[1], 
                        int.Parse(commandArgs[2]), 
                        decimal.Parse(commandArgs[3]));

                    persons.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");

            //decimal percentage = decimal.Parse(Console.ReadLine());

            //persons.ForEach(p => p.IncreaseSalary(percentage));
            //persons.ForEach(p => Console.WriteLine(p.ToString()));

        }
    }
}
