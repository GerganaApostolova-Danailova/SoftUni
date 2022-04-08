using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();


            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] command = line.Split(" : ").ToArray();

                string course = command[0];
                string name = command[1];


                if (courses.ContainsKey(course) == false)
                {
                    courses.Add(course, new List<string>());
                    courses[course].Add(name);
                }
                else
                {
                courses[course].Add(name);
                }

            }

            foreach (var kvp in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                foreach (var item in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {item}");
                }
            } 
        }
    }
}
