using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string department = input[2];

                Employee employee = new Employee(name, salary, department);
                employees.Add(employee);
            }

            var emplyeeWhithHighesSalary = employees.OrderByDescending(x => x.Salary);

            foreach (var emplyee in emplyeeWhithHighesSalary)
            {
                Console.WriteLine($"{emplyee.Name} {emplyee.Salary:f2} {emplyee.Department}");
            }
        }
    }
}
