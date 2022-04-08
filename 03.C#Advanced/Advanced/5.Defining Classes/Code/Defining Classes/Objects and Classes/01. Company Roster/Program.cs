using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _01._Company_Roster
{
    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        public Employee(string name, double salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, List<double>>();

            List<Employee> employes = new List<Employee>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                string name = input[0];
                double salary = double.Parse(input[1]);
                string department = input[2];


                if (!dict.ContainsKey(department))
                {
                    dict.Add(department, new List<double>());

                }
                dict[department].Add(salary);

                Employee currentEnployee = new Employee(name,salary,department);

                employes.Add(currentEnployee);


            }
                foreach (var kvp in dict.OrderByDescending(x=>x.Value.Sum()/x.Value.Count))
                {
                    Console.WriteLine($"Highest Average Salary: {kvp.Key}");

                    foreach (var employee in employes.OrderByDescending(x=>x.Salary))
                    {
                        if (employee.Department == kvp.Key)
                        {
                            Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
                        }
                    }
                    break;
                }
        }
    }
}
