﻿using System;
using System.Collections.Generic;

namespace _02._Oldest_Family_Member
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }

            Person oldestPerson = family.GetOldestMember();

            
                Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
            
        }
    }
}
