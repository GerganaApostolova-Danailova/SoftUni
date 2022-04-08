using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _05._Students
{
    class Program
    {

        class Student
        {
            public string FirstName { get; set; }
            public string LastNAme { get; set; }
            public int Age { get; set; }
            public string City { get; set; }

        }
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>();

            while (true)
            {
            string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                List<string> input = command
                    .Split()
                    .ToList();

                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                string city = input[3];

                Student student = new Student();

                student.FirstName = firstName;
                student.LastNAme = lastName;
                student.Age = age;
                student.City = city;


                students.Add(student);
            }
            string cityToPrint = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.City == cityToPrint)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastNAme} is {student.Age} years old.");
                }
            }
        }
    }
}
