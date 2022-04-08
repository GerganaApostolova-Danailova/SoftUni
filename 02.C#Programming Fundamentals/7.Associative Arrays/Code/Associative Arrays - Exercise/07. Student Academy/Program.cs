using System;
using System.Collections.Generic;
using System.Linq;


namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> nameWithGrade = new Dictionary<string, List<double>>();

            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!nameWithGrade.ContainsKey(name))
                {
                    nameWithGrade.Add(name, new List<double>());
                  
                }
                
                    nameWithGrade[name].Add(grade);
               
            }

            nameWithGrade = nameWithGrade
                .Where(x => x.Value.Average() >= 4.5)
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(x=> x.Key, x => x.Value);

            foreach (var item in nameWithGrade)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
            }
        }
    }
}
