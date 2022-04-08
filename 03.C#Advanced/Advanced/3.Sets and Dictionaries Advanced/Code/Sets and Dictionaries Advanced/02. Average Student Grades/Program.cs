using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();

            for (int i = 0; i < number; i++)
            {
                string[] students = Console.ReadLine()
                    .Split();

                string name = students[0];
                double grade = double.Parse(students[1]);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<double>());
                }

                dict[name].Add(grade);
            }
            foreach (var student in dict)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ",student.Value.Select(x=>x.ToString("f2")))} (avg: {student.Value.Average():f2})");
            }
        }
    }
}
