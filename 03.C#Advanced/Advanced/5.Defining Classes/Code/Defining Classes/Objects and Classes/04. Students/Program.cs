using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _04._Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName, string secondNAme, double grade)
        {
            this.FirstName = firstName;
            this.SecondName = secondNAme;
            this.Grade = grade;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < number; i++)
            {
                var list = Console.ReadLine()
                    .Split();

                Student student = new Student(list[0], list[1], double.Parse(list[2]));

                students.Add(student);
            }

            foreach (var student in students.OrderByDescending(x=>x.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.SecondName}: {student.Grade:f2}");
            }
        }
    }
}
