using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            List<Student> students = new List<Student>();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] currentStudent = command.Split();

                string firstName = currentStudent[0];
                string lastName = currentStudent[1];
                int age = int.Parse(currentStudent[2]);
                string town = currentStudent[3];

                bool isExist = IsStudentExisting(students, firstName, lastName);

                if (!isExist)
                {
                    Student student = new Student(firstName, lastName, age, town);
                    students.Add(student);
                }
                else
                {
                    foreach (var student in students)
                    {
                        if (student.FirstName == firstName && student.LastName == lastName)
                        {
                            student.Age = age;
                            student.HomeTown = town;
                        }
                    }
                }

            }

            string currentTown = Console.ReadLine();

            var studentByTown = students
                .Where(x => x.HomeTown == currentTown);

            foreach (var student in studentByTown)
            {
                Console.WriteLine(student);
            }
        }

        private static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }

            }
            return false;
        }

        public class Student
        {
            public Student(string firstName, string lastName, int age, string homeTown)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Age = age;
                this.HomeTown = homeTown;
            }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int Age { get; set; }

            public string HomeTown { get; set; }

            public override string ToString()
            {
                return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
            }
        }
    }
}
